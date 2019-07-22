using System;
using System.Collections.Generic;
using System.Linq;
using App.Modules.All.Infrastructure.Exceptions;
using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Services.Statuses;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Contract for an Infrastructure Service to
    ///     manage the recording of information as to whether
    ///     services were configured or not, so 
    ///     
    ///     that can later be queried by Application and Infrastructure
    ///     Support Specialists, via appropriate APIs.
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IConfigurationStatusService" />
    public class ConfigurationStatusService : IConfigurationStatusService
    {
        /// <summary>
        /// Gets a value indicating whether this
        /// <see cref="ConfigurationStatusService"/> is initialized.
        /// </summary>
        public bool Initialized { get; private set; }

        private bool _initializing;

        private static Dictionary<Type, ConfigurationStatusComponentBase> _cache = 
            new Dictionary<Type, ConfigurationStatusComponentBase>();

        private readonly IDependencyResolutionService _dependencyResolutionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationStatusService"/> class.
        /// </summary>
        /// <param name="dependencyResolutionService">The dependency resolution service.</param>
        public ConfigurationStatusService(
            IDependencyResolutionService dependencyResolutionService)
        {
            this._dependencyResolutionService = dependencyResolutionService;
        }


        public void Initialize()
        {
            if (this.Initialized)
            {
                return;
            }
            if (this._initializing)
            {
                return;
            }

            this._initializing = true;
            _dependencyResolutionService
                .GetAllInstances<IConfigurationComponentStatus>()
                //.Select(x => x as ConfigurationStatusComponentBase)
                .ForEach(x =>
                    Register(
                        x.GetType(),
                        x.Title,
                        x.Description,
                        "" ));
            


            var interfacesToDescribe =
                AppDomain.CurrentDomain.GetContractsDecoratedByAttribute(
                typeof(IHasPing),
                typeof(TitleDescriptionAttribute), false);

            foreach (Type interfaceType in interfacesToDescribe)
            {

                var titleDescriptionAttribute =
                    interfaceType.GetCustomAttribute<TitleDescriptionAttribute>(
                        true);

                if (titleDescriptionAttribute == null)
                {
                    // Now what?!?
                    continue;

                }
                var result =
                    Register(
                    interfaceType,
                    titleDescriptionAttribute.Title,
                    titleDescriptionAttribute.Description,
                    titleDescriptionAttribute.Instructions
                );

                var instance =
                    _dependencyResolutionService.GetInstance(interfaceType);

                try
                {
                    var pingResult = ((IHasPing) instance).Ping();

                    if (pingResult == true)
                    {
                        result.Status = ConfigurationStatusComponentStatusType
                            .ConfigurationVerified;
                        result.Steps.Clear();
                        result.AddStep(
                            ConfigurationStatusComponentStepType.General,
                            ConfigurationStatusComponentStepStatusType.Pass,
                            "Ping",
                            "Success");
                    }
                    else
                    {
                        result.Status = ConfigurationStatusComponentStatusType
                            .ConfigurationError;
                        result.Steps.Clear();
                        result.AddStep(
                            ConfigurationStatusComponentStepType.General,
                            ConfigurationStatusComponentStepStatusType.Fail,
                            "Ping",
                            "Failure");
                    }
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (System.Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    result.Status = ConfigurationStatusComponentStatusType
                        .ConfigurationError;
                    result.AddStep(
                        ConfigurationStatusComponentStepType.General,
                        ConfigurationStatusComponentStepStatusType.Fail,
                        "Ping",
                        "Failure");

                }

            }

            this._initializing = false;
            this.Initialized = true;
        }

        /// <summary>
        /// Registers the specified service interface type.
        /// Creates a new <see cref="ConfigurationStatusComponent"/>
        /// for the given <paramref name="serviceInterfaceType"/>
        /// and caches it.
        /// </summary>
        /// <param name="serviceInterfaceType">Type of the service interface.</param>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="instructions">The instructions.</param>
        /// <returns></returns>
        private ConfigurationStatusComponentBase Register(
            Type serviceInterfaceType,
            string title,
            string description,
            string instructions)
        {
            ConfigurationStatusComponentBase result;
            if (_cache.ContainsKey(serviceInterfaceType))
            {
                result = _cache[serviceInterfaceType];
            }
            else
            {
                result = new ConfigurationStatusComponent(
                    title,
                    description,
                    instructions
                );
                _cache[serviceInterfaceType] = result;
            }
            return result;
        }


        public void AddStep<TInterface>(ConfigurationStatusComponentStepType type,
            ConfigurationStatusComponentStepStatusType color,
            string title,
            string description)
        {
            if (!GetConfigObject<TInterface>(out var result))
            {
                return;
            }

            result.AddStep(type, color, title, description);
        }

        /// <summary>
        /// Gets the queryable set
        /// of (mem) cached singleton instances of
        /// <see cref="ConfigurationStatusComponentStep" />
        /// that were developed throughout the app
        /// to record whether services were correctly configured or not.
        /// <para>
        /// Invoked via the Service Facade.
        /// </para>
        /// </summary>
        /// <returns></returns>
        public IQueryable<ConfigurationStatusComponentBase> GetComponents()
        {
            Initialize();

            IQueryable<ConfigurationStatusComponentBase> results;
            try
            {

                results = 
                    _cache.Values
                    .Select(x => x as ConfigurationStatusComponentBase)
                    .OrderByDescending(x => x.DisplayOrderHint)
                    .ThenByDescending(x => x.Title)
                    .AsQueryable();

                //results = _dependencyResolutionService

                //    .GetAllInstances<IConfigurationComponentStatus>()
                //    .Select(x => x as ConfigurationStatusComponentBase)
                //    .OrderByDescending(x => x.DisplayOrderHint)
                //    .ThenByDescending(x => x.Title)
                //    .AsQueryable();
            }
            catch
            {
                throw new ConfigurationException(
                    "Probably have a class inheriting directly from IConfigurationStatus, and not from ConfigurationStatusBase.");
            }

            return results;
        }

        public IQueryable<ConfigurationStatus> Get()
        {
            Initialize();

            var result = new ConfigurationStatus()
            {
                Title = "...",
                Description = "..."
            };
            result.Components.AddRange(GetComponents());

            return (new ConfigurationStatus[] { result }).AsQueryable();
        }


        public void SetStatusToVerified<TInterface>()
        {
            if (!GetConfigObject<TInterface>(out var result))
            {
                return;
            }

            result.SetToVerified();
        }

        private static bool GetConfigObject<TInterface>(
            out ConfigurationStatusComponentBase result)
        {
            if (!_cache.TryGetValue(typeof(TInterface), out ConfigurationStatusComponentBase tmp))
            {
                result = null;
                return false;
            }

            result = tmp as ConfigurationStatusComponentBase;
            return result != null;
        }

        public void SetStatusToError<TInterface>(Exception e)
        {
            if (!GetConfigObject<TInterface>(out var result))
            {
                return;
            }

            result.SetToErrorIfNotYetVerified(e);

        }

        public void SetStatusToError<TInterface>(string reason)
        {
            if (!GetConfigObject<TInterface>(out var result))
            {
                return;
            }

            result.SetToErrorIfNotYetVerified(reason);
        }

    }
}

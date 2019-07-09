using System;
using System.Collections.Generic;
using System.Linq;
using App.ExtensionMethods;
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
        private static Dictionary<Type, object> _cache = new Dictionary<Type, object>();

        private readonly IDependencyResolutionService _dependencyResolutionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationStatusService"/> class.
        /// </summary>
        /// <param name="dependencyResolutionService">The dependency resolution service.</param>
        public ConfigurationStatusService(
            IDependencyResolutionService dependencyResolutionService)
        {
            this._dependencyResolutionService = dependencyResolutionService;
            Initialize();
        }


        public void Initialize()
        {
            //_dependencyResolutionService
            //    .GetAllInstances<IConfigurationComponentStatus>()
            //    .Select(x => x as ConfigurationStatusComponentBase)
            //    .ForEach(x => 
            //        Register(
            //            x.Title, 
            //            x.Description, 
            //            x.ConfigurationInstructions));



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
                Register(
                    interfaceType,
                    titleDescriptionAttribute.Title,
                    titleDescriptionAttribute.Description,
                    titleDescriptionAttribute.Instructions
                );
            }
        }


        public void Register(
            Type serviceInterfaceType,
            string title,
            string description,
            string instructions)
        {
            _cache[serviceInterfaceType] =
                new ConfigurationStatusComponent(
                    title,
                    description,
                    instructions
                );
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
            if (!_cache.TryGetValue(typeof(TInterface), out object tmp))
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

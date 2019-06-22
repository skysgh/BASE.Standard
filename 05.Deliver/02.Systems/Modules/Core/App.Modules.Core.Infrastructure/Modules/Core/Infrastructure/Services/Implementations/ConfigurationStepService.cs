// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;
using System.Linq;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IConfigurationStepService" />
    ///     Infrastructure Service Contract
    ///     <para>
    ///         Implementation of the Infrastructure Service Contract to
    ///         manage the recording of Setup Configuration Steps
    ///         that can later be queried by Application and Infrastructure
    ///         Support Speialists, via appropriate APIs.
    ///     </para>
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IConfigurationStepService" />
    public class ConfigurationStepService : AppCoreServiceBase, IConfigurationStepService
    {
        /// <summary>
        ///     Host Specific, in-mem cache.
        ///     TODO: May need something more resilient when we get to a load-balanced, multi-host environment. To watch...
        /// </summary>
        private static readonly List<ConfigurationStepRecord> _cache = new List<ConfigurationStepRecord>();

        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IUniversalDateTimeService _universalDateTimeService;


        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigurationStepService" /> class.
        /// </summary>
        /// <param name="universalDateTimeService">The universal date time service.</param>
        public ConfigurationStepService(
            IUniversalDateTimeService universalDateTimeService,
            IDiagnosticsTracingService diagnosticsTracingService)
        {
            _universalDateTimeService = universalDateTimeService;
            _diagnosticsTracingService = diagnosticsTracingService;
        }

        /// <summary>
        ///     Registers the specified <see cref="ConfigurationStepRecord" />.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="status">The status.</param>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        public void Register(ConfigurationStepType type, ConfigurationStepStatus status, string title,
            string description)
        {
            var configurationStep = new ConfigurationStepRecord
            {
                UtcDateTimeCreated = _universalDateTimeService.NowUtc(),
                Type = type,
                Status = status,
                Title = title,
                Description = description
            };
            _cache.Add(configurationStep);

            var traceLevel = TraceLevel.Info;
            if (status == ConfigurationStepStatus.Orange)
            {
                traceLevel = TraceLevel.Warn;
            }

            if (status == ConfigurationStepStatus.Red)
            {
                traceLevel = TraceLevel.Warn;
            }

            _diagnosticsTracingService.Trace(TraceLevel.Verbose, "");
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, "-=-=-=-=-=-=-=-=-=-=");
            _diagnosticsTracingService.Trace(traceLevel,
                $"Status: {status}; Type: {type}; Title: {title}; Description: {description}");
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Status: {status}");
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Type: {type}");
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Title: {title}");
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Description: {description}");
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, "-=-=-=-=-=-=-=-=-=-=");
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, "");
        }

        /// <summary>
        ///     Gets the (mem) cached <see cref="ConfigurationStepRecord" />s.
        ///     <para>
        ///         Invoked via the Service Facade.
        ///     </para>
        /// </summary>
        /// <returns></returns>
        public IQueryable<ConfigurationStepRecord> Get()
        {
            return _cache.AsReadOnly().AsQueryable();
        }
    }
}
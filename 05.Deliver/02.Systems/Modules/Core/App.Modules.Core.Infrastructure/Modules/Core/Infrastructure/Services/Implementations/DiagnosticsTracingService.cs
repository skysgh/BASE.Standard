// Copyright MachineBrains, Inc. 2019

using System.Threading;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IDiagnosticsTracingService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IDiagnosticsTracingService" />
    public class DiagnosticsTracingService : AppCoreServiceBase, IDiagnosticsTracingService
    {
        private LogLevel _minLogLevel;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticsTracingService"/> class.
        /// </summary>
        public DiagnosticsTracingService(IConfiguration configuration)
        {
            this._configuration = configuration;
            _minLogLevel = _configuration.GetValue<LogLevel>("Logging:LogLevel:Default");
        }

        /// <summary>
        /// Record the provided message, using the specified trace level.
        /// </summary>
        /// <param name="traceLevel">The trace level.</param>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The arguments.</param>
        public void Trace(TraceLevel traceLevel, string message, params object[] arguments)
        {

            //LogLevel:
            //Trace = 0,
            //Debug = 1,
            //Information = 2,
            //Warning = 3,
            //Error = 4,
            //Critical = 5,
            //None = 6,

            //TraceLevel:
            //Critical = 0, 5-0=5
            //Error = 1,    5-1=4
            //Warn = 2,     5-2=3
            //Info = 3,     5-3=2
            //Debug = 4,    5-4=1
            //Verbose = 5   5-5=0

            if ((5-(int)traceLevel) < (int)_minLogLevel)
            {
                return;
            }

            if (arguments != null && arguments.Length > 0)
            {
                message = string.Format(message, arguments);
            }

            var name = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            var threadId = Thread.CurrentThread.Name ?? Thread.CurrentThread.ManagedThreadId.ToString();
            string level;

            switch (traceLevel)
            {
                case TraceLevel.Info:
                    level = "Information";
                    break;
                case TraceLevel.Warn:
                    level = "Warning";
                    break;
                default:
                    level = traceLevel.ToString();
                    break;
            }
            
            System.Diagnostics.Trace.WriteLine($"{name}:{threadId}:{level}:{message}");
        }
    }
}
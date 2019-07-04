// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for an Infrastructure Service to
    ///     provide diagnostic tracing services.
    ///     <para>
    ///         In Azure these trace messages would probably be recored to
    ///         Blob storage.
    ///     </para>
    /// </summary>
    /// <seealso cref="IInfrastructureService" />
    public interface IDiagnosticsTracingService : IInfrastructureService
    {

        /// <summary>
        /// Record the provided message, using the specified trace level.
        /// </summary>
        /// <param name="traceLevel">The trace level.</param>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The arguments.</param>
        void Trace(TraceLevel traceLevel, string message, params object[] arguments);
    }
}
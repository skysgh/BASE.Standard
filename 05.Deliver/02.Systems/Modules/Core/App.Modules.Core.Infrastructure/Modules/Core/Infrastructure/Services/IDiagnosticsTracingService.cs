using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    /// Contract for an Infrastructure Service to 
    /// provide diagnostic tracing services.
    /// <para>
    /// In Azure these trace messages would probably be recored to 
    /// Blob storage.
    /// </para>
    /// </summary>
    /// <seealso cref="IInfrastructureService" />
    public interface IDiagnosticsTracingService : IInfrastructureService
    {
        void Trace(TraceLevel traceLevel, string message, params object[] arguments);
    }
}
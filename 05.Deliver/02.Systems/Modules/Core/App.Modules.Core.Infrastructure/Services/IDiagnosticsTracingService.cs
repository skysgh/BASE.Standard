namespace App.Modules.Core.Infrastructure.Services
{
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Contracts.Services;

    /// <summary>
    /// Contract for an Infrastructure Service to 
    /// provide diagnostic tracing services.
    /// <para>
    /// In Azure these trace messages would probably be recored to 
    /// Blob storage.
    /// </para>
    /// </summary>
    /// <seealso cref="IModuleSpecificService" />
    public interface IDiagnosticsTracingService : IModuleSpecificService
    {
        void Trace(TraceLevel traceLevel, string message, params object[] arguments);
    }
}
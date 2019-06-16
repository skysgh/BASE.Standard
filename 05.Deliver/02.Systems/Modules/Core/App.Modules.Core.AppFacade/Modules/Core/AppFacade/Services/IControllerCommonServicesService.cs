using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.AppFacade.Services
{
    /// <summary>
    /// Service to inject into Controllers
    /// (OData or traditional Api)
    /// that return persisted records of 
    /// some kind.
    /// <para>
    /// The purpose of the Controller is only 
    /// to make the injection of services into
    /// Controllers a bit less repetitive -- 
    /// and the Constructors
    /// easier to update if the number/type of
    /// common services were changed in the future.
    /// </para>
    /// </summary>
    public interface IControllerCommonServicesService
    //<TDbContext>
    //where TDbContext : DbContext
    {

        //TDbContext DbContext { get; }

        /// <summary>
        /// Gets the diagnostics tracing service.
        /// </summary>
        /// <value>
        /// The diagnostics tracing service.
        /// </value>
        IDiagnosticsTracingService DiagnosticsTracingService { get; }
        /// <summary>
        /// Gets the principal service.
        /// </summary>
        /// <value>
        /// The principal service.
        /// </value>
        IPrincipalService PrincipalService { get; }
        /// <summary>
        /// Gets the tenant service.
        /// </summary>
        /// <value>
        /// The tenant service.
        /// </value>
        ITenantService TenantService { get; }
        /// <summary>
        /// Gets the object mapping service.
        /// </summary>
        IObjectMappingService ObjectMappingService { get; }
        /// <summary>
        /// Gets the secure API message service.
        /// </summary>
        ISecureAPIMessageAttributeService SecureApiMessageAttribute { get; }
    }
}

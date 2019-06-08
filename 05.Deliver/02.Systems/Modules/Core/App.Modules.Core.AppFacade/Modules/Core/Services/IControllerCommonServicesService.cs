using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Services
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

        IDiagnosticsTracingService DiagnosticsTracingService { get; }
        IPrincipalService PrincipalService { get; }
        ITenantService TenantService { get; }
        IObjectMappingService ObjectMappingService { get; }
        ISecureAPIMessageAttributeService SecureApiMessageAttribute { get; }
    }
}

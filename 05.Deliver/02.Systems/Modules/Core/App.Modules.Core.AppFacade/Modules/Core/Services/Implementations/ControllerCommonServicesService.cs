using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Services.Implementations
{
    public class ControllerCommonServicesService
        //<TDbContext> 
        : IControllerCommonServicesService
        //<TDbContext> where TDbContext : DbContext
    {
        public ControllerCommonServicesService(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            ITenantService tenantService,
            IObjectMappingService objectMappingService,
            ISecureAPIMessageAttributeService secureApiMessageAttribute)
        {
            DiagnosticsTracingService = diagnosticsTracingService;
            PrincipalService = principalService;
            TenantService = tenantService;
            ObjectMappingService = objectMappingService;
            SecureApiMessageAttribute = secureApiMessageAttribute;
        }

        //public TDbContext DbContext { get; }

        public IDiagnosticsTracingService DiagnosticsTracingService { get; }
        public IPrincipalService PrincipalService { get; }
        public ITenantService TenantService { get; }
        public IObjectMappingService ObjectMappingService { get; }
        public ISecureAPIMessageAttributeService SecureApiMessageAttribute { get; }
    }
}

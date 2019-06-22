// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.AppFacade.Services.Implementations
{
    /// <summary>
    ///     A collection of commonly used services.
    ///     <para>
    ///         Facilitates and simplifies the creation of
    ///         Controllers.
    ///     </para>
    /// </summary>
    /// <seealso cref="App.Modules.Core.AppFacade.Services.IControllerCommonServicesService" />
    public class ControllerCommonServicesService
        //<TDbContext> 
        : IControllerCommonServicesService
        //<TDbContext> where TDbContext : DbContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ControllerCommonServicesService" /> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="tenantService">The tenant service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="secureApiMessageAttribute">The secure API message attribute.</param>
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

        /// <summary>
        ///     Gets the diagnostics tracing service.
        /// </summary>
        /// <value>
        ///     The diagnostics tracing service.
        /// </value>
        public IDiagnosticsTracingService DiagnosticsTracingService { get; }

        /// <summary>
        ///     Gets the principal service.
        /// </summary>
        /// <value>
        ///     The principal service.
        /// </value>

        public IPrincipalService PrincipalService { get; }

        /// <summary>
        ///     Gets the tenant service.
        /// </summary>
        /// <value>
        ///     The tenant service.
        /// </value>
        public ITenantService TenantService { get; }

        /// <summary>
        ///     Gets the object mapping service.
        /// </summary>
        /// <value>
        ///     The object mapping service.
        /// </value>
        public IObjectMappingService ObjectMappingService { get; }

        /// <summary>
        ///     Gets the secure API message attribute.
        /// </summary>
        /// <value>
        ///     The secure API message attribute.
        /// </value>
        public ISecureAPIMessageAttributeService SecureApiMessageAttribute { get; }
    }
}
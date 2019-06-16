// Copyright MachineBrains, Inc.

using App.Modules.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Routing;

namespace App.Modules.Core.AppFacade.Initialization.Startup
{

    /// <summary>
    /// This Module's specific routes.
    /// <para>
    /// Invoked from Startup/Configure method,
    /// within .AddMvc...
    /// </para>
    /// </summary>
    public class ModuleRoutes : ModuleRoutesBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleRoutes"/> class.
        /// </summary>
        /// <param name="dependencyResolutionService">The dependency resolution service.</param>
        /// <param name="configurationStepService">The configuration step service.</param>
        public ModuleRoutes(
            IDependencyResolutionService dependencyResolutionService,
            IConfigurationStepService configurationStepService)
            : base(dependencyResolutionService, configurationStepService)
        {
        }


        /// <summary>
        /// Initialize routes specific to a Module.
        /// <para>
        /// Invoked from app.AddMvc(routeBuilder =&gt; ...) method.
        /// within App.Host's Setup/Configure method.
        /// </para><para>
        /// Use as required to register routes specific to a single Module.
        /// </para><para>
        /// Base class invokes <see cref="ModuleRoutesBase.CreateODataRoutes" /></para>
        /// </summary>
        /// <param name="routeBuilder">The route builder.</param>
        public override void Initialize(IRouteBuilder routeBuilder)
        {
            // Base registers OData controller routes:
            base.Initialize(routeBuilder);
        }
    }
}
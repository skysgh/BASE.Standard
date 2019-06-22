// Copyright MachineBrains, Inc. 2019

using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.All.AppFacade.Controllers.Configuration.Routes;
using App.Modules.All.AppFacade.DependencyResolution;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Routing;

namespace App.Modules.Design.AppFacade.Controllers.Configuration.Routes
{
    /// <summary>
    ///     Defines this Module's
    ///     Controller Routes (ie, Api, Views, OData).
    ///     <para>
    ///     Scanned for and found by <see cref="AllModulesAppFacadeServiceRegistry"/>
    ///     </para>
    ///     <para>
    ///         Invoked from app.AddMvc(routeBuilder => ...) method.
    ///         within App.Host's Setup.cs/Configure method.
    ///     </para>
    ///     <para>
    ///     The base class already defines common routing for View Controllers,
    ///     API Controllers and OData Controllers found within this Logical Module.
    ///     </para>
    ///     <para>
    ///     The common OData convention setup via the base controller is 
    ///     "odata/{moduleName}/{controllerName}" based on the
    ///     implementation of <see cref="IModuleOdataModelBuilderConfiguration"/>
    ///     (via <see cref="ModuleGuidIdODataModelBuilderConfigurationBase{T}"/> for example)
    ///     it found in this logical module.
    ///     </para>
    ///     <para>
    ///     In general, one should probably not have to define anything,
    ///     and just let the base class do it's thing -- but if this module
    ///     has esoteric odata needs, this would be the method to override
    ///     and append those routes.
    ///     </para>
    /// </summary>
    public class ModuleRoutes : ModuleRoutesBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ModuleRoutes" /> class.
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
        ///     Initialize routes specific to a Module.
        ///     <para>
        ///         Invoked from app.AddMvc(routeBuilder => ...) method.
        ///         within App.Host's Setup/Configure method.
        ///     </para>
        ///     <para>
        ///     The base class already defines common routing for View Controllers,
        ///     API Controllers and OData Controllers found within this Logical Module.
        ///     </para>
        ///     <para>
        ///     The common OData convention setup via the base controller is 
        ///     "odata/{moduleName}/{controllerName}" based on the
        ///     implementation of <see cref="IModuleOdataModelBuilderConfiguration"/>
        ///     (via <see cref="ModuleGuidIdODataModelBuilderConfigurationBase{T}"/> for example)
        ///     it found in this logical module.
        ///     </para>
        ///     <para>
        ///     In general, one should probably not have to define anything,
        ///     and just let the base class do it's thing -- but if this module
        ///     has esoteric odata needs, this would be the method to override
        ///     and append those routes.
        ///     </para>
        /// </summary>
        /// <param name="routeBuilder"></param>
        public override void Initialize(IRouteBuilder routeBuilder)
        {
            // Base registers OData controller routes:
            base.Initialize(routeBuilder);
        }
    }
}
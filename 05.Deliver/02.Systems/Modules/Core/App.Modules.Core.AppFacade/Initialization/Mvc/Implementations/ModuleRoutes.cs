// Copyright MachineBrains, Inc.

using App.Modules.Core.AppFacade.Initialization.OData;
using App.Modules.Core.Infrastructure.Services;
using Lamar;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage.Shared.Protocol;

namespace App.Modules.Core.AppFacade.Initialization.Mvc.Implementations
{
    /// <summary>
    /// This Module's specific routes.
    /// </summary>
    public class ModuleRoutes : IModuleRoutes
    {
        private readonly IDependencyResolutionService _dependencyResolutionService;
        protected string ModuleName => App.Modules.Core.Shared.Constants.Module.Id;

        public ModuleRoutes(IDependencyResolutionService dependencyResolutionService)
        {
            _dependencyResolutionService = dependencyResolutionService;
        }

        public void Initialize(IRouteBuilder routeBuilder)
        {
            RegisterModuleApiRoutes(routeBuilder);

            CreateODataRoutes(routeBuilder);
        }

        private static void RegisterModuleApiRoutes(IRouteBuilder routeBuilder)
        {
            // Route Names have to be unique:
            string moduleSpecificRoutePrefix = $"{App.Modules.Core.Shared.Constants.Module.Id}.";

            // ---- Area Based
            routeBuilder.MapRoute(
                name: $"{moduleSpecificRoutePrefix}defaultAreaRoute",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            routeBuilder.MapRoute(
                name: $"{moduleSpecificRoutePrefix}defaultApi",
                template: "api/{controller=Home}/{action=Index}/{id?}");

            routeBuilder.MapRoute(
                name: $"{moduleSpecificRoutePrefix}default",
                template: "{controller=Home}/{action=Index}/{id?}");
        }

        private void CreateODataRoutes(IRouteBuilder routeBuilder)
        {
            var oDataConventionModelBuilder = BuildODataModel();

            RegisterRoutesToODataController(routeBuilder, oDataConventionModelBuilder);
        }

        private static void RegisterRoutesToODataController(IRouteBuilder routeBuilder,
            ODataConventionModelBuilder oDataConventionModelBuilder)
        {
            string routePrefix = $"{App.Modules.Core.Shared.Constants.Module.AssemblyNamePrefix}.";

            // Register the Odata paths
            routeBuilder.MapODataServiceRoute(
                routeName: $"{routePrefix}odataDefault",
                routePrefix: "odata",
                oDataConventionModelBuilder.GetEdmModel()
            );
        }

        private ODataConventionModelBuilder BuildODataModel()
        {
            var oDataConventionModelBuilder =
                new ODataConventionModelBuilder();

            var modelDefinitions =
                _dependencyResolutionService.GetAllInstances<IAllModulesOdataModelBuilderConfiguration>();

            var version = new ApiVersion(0, 1);
            foreach (var x in modelDefinitions)
            {
                x.Apply(oDataConventionModelBuilder, version);
            }

            return oDataConventionModelBuilder;
        }
    }
}
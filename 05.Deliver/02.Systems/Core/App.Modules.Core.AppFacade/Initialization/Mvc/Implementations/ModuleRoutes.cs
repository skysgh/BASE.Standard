// Copyright MachineBrains, Inc.

using App.Modules.Core.Infrastructure.Services;
using Lamar;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNet.OData.Builder;

namespace App.Modules.Core.AppFacade.Initialization.Mvc.Implementations
{
    public class ModuleRoutes : IModuleRoutes
    {
         
        public void Initialize(IRouteBuilder routeBuilder)
        {

            // ---- Area Based
            routeBuilder.MapRoute(
                name: "defaultAreaRoute",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            routeBuilder.MapRoute(
                name: "defaultApi",
                template: "api/{controller=Home}/{action=Index}/{id?}");

            routeBuilder.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");

            var oDataConventionModelBuilder = new ODataConventionModelBuilder();

            // Register the Odata paths
            routeBuilder.MapODataServiceRoute(
                routeName: "odataDefault",
                routePrefix: "odata",
                oDataConventionModelBuilder.GetEdmModel()
            );


        }

    }
}
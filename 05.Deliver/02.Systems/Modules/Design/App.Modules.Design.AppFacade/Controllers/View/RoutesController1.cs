using System.Linq;
using App.Modules.All.AppFacade.Controllers.Api.OData;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Design.Shared.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace App.Modules.Design.AppFacade.Controllers.View
{

    /// <summary>
    /// A Router to return all registered Routes.
    /// </summary>
    /// <seealso cref="App.Modules.All.AppFacade.Controllers.Api.OData.CommonODataControllerBase" />
    public class RoutesController : CommonODataControllerBase
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoutesController"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="actionDescriptorCollectionProvider">The action descriptor collection provider.</param>
        public RoutesController(
            IDiagnosticsTracingService diagnosticsTracingService, 
            IPrincipalService principalService, 
            IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
            :base(
                 diagnosticsTracingService,
                 principalService)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        /// <summary>
        /// Gets all routes.
        /// </summary>
        /// <returns></returns>
        public IActionResult GetAllRoutes()
        {
            var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items
                .Where(ad => ad.AttributeRouteInfo != null)
                .Select(ad => new Route
                {
                    Name = ad.AttributeRouteInfo.Name,
                    Template = ad.AttributeRouteInfo.Template
                })
                .ToList();

            return Ok(routes);
        }
    }
}

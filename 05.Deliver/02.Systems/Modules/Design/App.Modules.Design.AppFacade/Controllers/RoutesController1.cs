﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Modules.Core.AppFacade.Controllers.Api.odata.Base;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Design.Shared.Models.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace App.Modules.Design.AppFacade.Initialization.OData
{

    public class RoutesController : CommonODataControllerBase
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

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

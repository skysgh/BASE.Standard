using System;
using App.Modules.All.AppFacade.Controllers.Api.OData;
using App.Modules.Core.AppFacade.Services;
using App.Modules.TKWMODULENAME.Infrastructure.Data.Db.Contexts;
using App.Modules.TKWMODULENAME.Shared.Models.Entities;
using App.Modules.TKWMODULENAME.Shared.Models.Messages;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.TKWMODULENAME.AppFacade.Controllers.Api.OData
{
    public class TenantedExamplesController
         : GuidIdCommonODataControllerBase<
            ModuleDbContext,
            TenantedExample,
            TenantedExampleDto>
    {
        public TenantedExamplesController(
            IControllerCommonServicesService controllerCommonServicesService,
            JoinedModuleDbContext dbContext)
            : base(controllerCommonServicesService, dbContext)
        {
        }

        [EnableQuery(PageSize = 100)]
        public IActionResult Get()
        {
            return Ok(InternalGet());
        }


        //[ODataRoute("({key})")]
        [EnableQuery()]
        public IActionResult Get([FromODataUri] Guid key)
        {
            return Ok();
        }

    }
}

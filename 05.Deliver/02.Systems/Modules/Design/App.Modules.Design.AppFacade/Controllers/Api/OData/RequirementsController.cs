﻿using System;
using App.Modules.Core.Controllers.Api.OData.Base;
using App.Modules.Core.Services;
using App.Modules.Design.Infrastructure.Data.Db.Contexts;
using App.Modules.Design.Shared.Models.Entities.NonTenantSpecific;
using App.Modules.Design.Shared.Models.Messages;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Design.AppFacade.Controllers.Api.OData
{
    public class RequirementsController
         : GuidIdCommonODataControllerBase<
            ModuleDbContext,
            Requirement,
            RequirementDto>
    {
        public RequirementsController(
            IControllerCommonServicesService controllerCommonServicesService,
            ModuleDbContext dbContext)
            : base(controllerCommonServicesService, dbContext)
        {
        }

        [EnableQuery(PageSize = 100)]
        public IActionResult GetRequirements()
        {
            return Ok(InternalGet());
        }


        //[ODataRoute("({key})")]
        [EnableQuery()]
        public IActionResult GetRequirement([FromODataUri] Guid key)
        {
            return Ok();
        }

    }
}
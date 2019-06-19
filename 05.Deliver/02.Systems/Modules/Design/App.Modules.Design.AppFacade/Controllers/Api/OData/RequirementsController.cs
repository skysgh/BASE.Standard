using System;
using App.Modules.All.AppFacade.Controllers.Api.OData;
using App.Modules.Core.AppFacade.Services;
using App.Modules.Design.Infrastructure.Data.Db.Contexts;
using App.Modules.Design.Shared.Models.Entities.NonTenantSpecific;
using App.Modules.Design.Shared.Models.Messages;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Design.AppFacade.Controllers.Api.OData
{
    /// <summary>
    /// Controller to return
    /// <see cref="RequirementDto"/>s.
    /// </summary>
    /// <seealso cref="GuidIdCommonODataControllerBase{ModuleDbContext, Requirement, RequirementDto}" />
    public class RequirementsController
         : GuidIdCommonODataControllerBase<
            ModuleDbContext,
            Requirement,
            RequirementDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequirementsController"/> class.
        /// </summary>
        /// <param name="controllerCommonServicesService">The controller common services service.</param>
        /// <param name="dbContext">The database context.</param>
        public RequirementsController(
            IControllerCommonServicesService controllerCommonServicesService,
            ModuleDbContext dbContext)
            : base(controllerCommonServicesService, dbContext)
        {
        }

        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <returns></returns>
        [EnableQuery(PageSize = 100)]
        public IActionResult GetRequirements()
        {
            return Ok(InternalGet());
        }


        //[ODataRoute("({key})")]
        /// <summary>
        /// Gets the requirement.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        [EnableQuery()]
        public IActionResult GetRequirement([FromODataUri] Guid key)
        {
            return Ok();
        }

    }
}

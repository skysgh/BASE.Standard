using System;
using System.Linq;
using App.Modules.Core.Controllers.Api.OData.Base;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Services;
using App.Modules.Design.Infrastructure.Data.Db.Contexts;
using App.Modules.Design.Shared.Models.Entities;
using App.Modules.Design.Shared.Models.Messages;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Design.AppFacade.Controllers.Api.OData
{
    public class ExamplesController
         : GuidIdCommonODataControllerBase<
             JoinedModuleDbContext,
            Example,
            ExampleDto>
    {
        public ExamplesController(
            IControllerCommonServicesService controllerCommonServicesService,
            JoinedModuleDbContext dbContext)
            : base(controllerCommonServicesService, dbContext)
        {
        }

        [EnableQuery(PageSize = 100)]
        public IActionResult GetExamples()
        {
            var check1 = base._dbContext.Set<Example>().ToArray();
            var check2 = base._dbContext.Set<DataClassification>().ToArray();
            //var check = base._dbContext.Set<Example>().Include(x=>x.DataClassification).ToArray();

            return Ok(InternalGet(x => x.DataClassification));
        }


        //[ODataRoute("({key})")]
        [EnableQuery()]
        public IActionResult GetExample([FromODataUri] Guid key)
        {
            return Ok();
        }

    }
}

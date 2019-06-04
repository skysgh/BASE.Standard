
using App.Modules.Core.Models.Entities;
using App.Modules.Models.Entities;
using App.Modules.Core.Models.Messages.API.V0100;

namespace App.Modules.Core.AppFacade.Controllers.Api.odata
{
    using System;
    using System.Linq;
    using App.Modules.Core.AppFacade.Controllers.Api.odata.Base;
    using App.Modules.Core.AppFacade.Services;
    using App.Modules.Core.Infrastructure.Data.Db.Contexts;
    using App.Modules.Models.Messages.API.V0100;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    /// <summary>
    /// OData Queryable REST Controller for
    /// <see cref="ExceptionRecordDto"/> messages 
    /// for Application Support Specialists to 
    /// query what Exceptions have happened of late.
    /// </summary>
    //[ODataRoutePrefix("ExceptionRecords")]
    public class ExceptionRecordsController :
        GuidIdCommonODataControllerBase<
            DbContext,
            ExceptionRecord,
            ExceptionRecordDto>
    {
        public ExceptionRecordsController(
            IControllerCommonServicesService controllerCommonServicesService,
            ModuleDbContext dbContext
            ) :
            base
            (
            controllerCommonServicesService,
            dbContext
            )
        {
        }


        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        //[ODataRoute()]
        [HttpGet("")]
        [HttpGet("List")]
        [EnableQuery(PageSize = 100)]
        public IQueryable<ExceptionRecordDto> Get()
        {
            return InternalGet();
        }


        //[ODataRoute("({key})")]
        public ExceptionRecordDto Get(Guid key)
        {
            return InternalGet(key);
        }

    }
}
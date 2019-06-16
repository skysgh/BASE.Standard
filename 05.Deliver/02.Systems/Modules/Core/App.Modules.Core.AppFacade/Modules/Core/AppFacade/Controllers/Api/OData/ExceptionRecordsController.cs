using System;
using System.Linq;
using App.Modules.All.AppFacade.Controllers.Api.OData;
using App.Modules.Core.AppFacade.Services;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData
{
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
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionRecordsController"/> class.
        /// </summary>
        /// <param name="controllerCommonServicesService">The controller common services service.</param>
        /// <param name="dbContext">The database context.</param>
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


        /// <summary>
        /// Invokes InternalGet
        /// to return a single Dto.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Invokes InternalGet
        /// to return a single dto object.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public ExceptionRecordDto Get(Guid key)
        {
            return InternalGet(key);
        }

    }
}
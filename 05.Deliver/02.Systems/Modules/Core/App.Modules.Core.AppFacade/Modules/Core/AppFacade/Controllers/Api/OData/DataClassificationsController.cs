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
    public class DataClassificationsController :
        ComparableIdCommonODataControllerBase<
            DbContext,
            DataClassification,
            DataClassificationDto,
            NZDataClassification>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataClassificationsController"/> class.
        /// </summary>
        /// <param name="controllerCommonServicesService">The controller common services service.</param>
        /// <param name="dbContext">The database context.</param>
        public DataClassificationsController(
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
        /// Gets a single DTO.
        /// </summary>
        /// <returns></returns>
        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        //[ODataRoute()]
        [HttpGet("")]
        [HttpGet("List")]
        [EnableQuery(PageSize = 100)]
        public IQueryable<DataClassificationDto> Get()
        {
            try
            {
                return InternalGet();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }


        //[ODataRoute("({key})")]
        /// <summary>
        /// Gets the specified entity
        /// via it's Key.
        /// <para>
        /// Example request:
        /// <code>
        /// https://localhost:5001/odata/core/dataclassifications(App.Modules.Models.Entities.NZDataClassification'Unclassified')
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public DataClassificationDto Get(NZDataClassification key)
        {
            var r = base.InternalGet(key);

            return r;
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public int Get(string key)
        {
            return 0;
            //NZDataClassification val;
            //if (!System.Enum.TryParse(key, out val))
            //{
            //    return null;
            //}

            //var r = base.InternalGet(val);
            //return r;

        }
        /// <summary>
        /// Fuzzs the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public int Fuzz(string key)
        {
            return 0;
            //NZDataClassification val;
            //if (!System.Enum.TryParse(key, out val))
            //{
            //    return null;
            //}

            //var r = base.InternalGet(val);
            //return r;

        }


    }
}
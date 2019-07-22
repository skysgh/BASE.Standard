// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using System.Linq.Expressions;
using App.Modules.All.AppFacade.Controllers.Api.OData;
using App.Modules.Core.AppFacade.Services;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Shared.Models.DTOs;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData
{
    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    /// <summary>
    ///     OData Queryable REST Controller for
    ///     <see cref="ExceptionRecordDto" /> messages
    ///     for Application Support Specialists to
    ///     query what Exceptions have happened of late.
    /// </summary>
    //[ODataRoutePrefix("ExceptionRecords")]
    public class DataClassificationsController :
        IdCommonODataControllerBase<
            DbContext,
            DataClassification,
            DataClassificationDto,
            NZDataClassification>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DataClassificationsController" /> class.
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
        ///     Gets a single DTO.
        /// </summary>
        /// <returns></returns>
        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        //[ODataRoute()]
        [HttpGet("")]
        [HttpGet("List")]
        [EnableQuery(PageSize = 100)]
        public override ActionResult<IQueryable<DataClassificationDto>> Get()
        {
            return InternalGet(RecordPersistenceState.Active);
        }


        //[ODataRoute("({key})")]
        /// <summary>
        ///     Gets the specified entity
        ///     via it's Key.
        ///     <para>
        ///         Example request:
        ///         <code>
        /// https://localhost:5001/odata/core/dataclassifications(App.Modules.Models.Entities.NZDataClassification'Unclassified')
        /// </code>
        ///     </para>
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public override ActionResult<DataClassificationDto> Get(NZDataClassification key)
        {
            return base.InternalGet(
                key, 
                RecordPersistenceState.Active);
        }

        /// <summary>
        ///     Gets the specified key.
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
        ///     Fuzzs the specified key.
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

        /// <summary>
        /// Creates the specified resource.
        /// <para>
        /// Override, and optionally invoke
        /// <see cref="M:App.Modules.All.AppFacade.Controllers.Api.OData.IdCommonODataControllerBase`4.InternalPost(`2)" /></para><para>
        /// If not desired,
        /// throw a <see cref="T:System.NotImplementedException" />.
        /// </para><para>
        /// Important:
        /// the method is abstract to force an override
        /// that is to be decorated by developers with
        /// a specification of the Permissions required.
        /// </para>
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override IActionResult Post(DataClassificationDto message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified resource.
        /// <para>
        /// Override, and optionally invoke
        /// <see cref="M:App.Modules.All.AppFacade.Controllers.Api.OData.Base.MappedCommonODataControllerBase`3.InternalPut(`2)" /></para><para>
        /// If not desired,
        /// throw a <see cref="T:System.NotImplementedException" />.
        /// </para><para>
        /// Important:
        /// the method is abstract to force an override
        /// that is to be decorated by developers with
        /// a specification of the Permissions required.
        /// </para>
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override IActionResult Put(DataClassificationDto message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the entity specified by the key.
        /// <para>
        /// Override, and optionally invoke
        /// <see cref="M:App.Modules.All.AppFacade.Controllers.Api.OData.IdCommonODataControllerBase`4.InternalDelete(`3)" /></para><para>
        /// If not desired,
        /// throw a <see cref="T:System.NotImplementedException" />.
        /// </para><para>
        /// Important:
        /// the method is abstract to force an override
        /// that is to be decorated by developers with
        /// a specification of the Permissions required.
        /// </para>
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override IActionResult Delete(NZDataClassification key)
        {
            throw new NotImplementedException();
        }
    }
}
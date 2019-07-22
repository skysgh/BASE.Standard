// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using App.Modules.All.AppFacade.Controllers.Api.OData;
using App.Modules.All.AppFacade.Controllers.Api.OData.Base;
using App.Modules.Core.AppFacade.Services;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Shared.Models.DTOs;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData
{
    /// <summary>
    ///     Controller to return DiagnosticsTrace messages
    ///     to authorised users.
    /// </summary>
    /// <seealso cref="CommonODataControllerBase" />
    [ODataRoutePrefix("DiagnosticsTraces")]
    public class DiagnosticsTracesController
        : GuidIdCommonODataControllerBase<
            ModuleDbContext,
            DiagnosticsTraceRecord,
            DiagnosticsTraceRecordDto>

    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DiagnosticsTracesController" /> class.
        /// </summary>
        /// <param name="controllerCommonServicesService">The controller common services service.</param>
        /// <param name="dbContext">The database context.</param>
        public DiagnosticsTracesController(
            IControllerCommonServicesService controllerCommonServicesService,
            ModuleDbContext dbContext) :
            base(controllerCommonServicesService, dbContext)
        {
        }


        /// <summary>
        ///     Gets a queryable set of
        ///     <see cref="DiagnosticsTraceRecordDto" />
        ///     objects.
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IQueryable<DiagnosticsTraceRecordDto>> Get()
        {
            //return null;
            return base.InternalGet(RecordPersistenceState.Active);
        }

        /// <summary>
        /// Gets a single entity, from the given Id.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public override ActionResult<DiagnosticsTraceRecordDto> Get([FromODataUri] Guid key)
        {
            return base.InternalGet(key, RecordPersistenceState.Active);
        }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override IActionResult Post(DiagnosticsTraceRecordDto value)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///     Record a Diagnostics Message, if authorised to do so.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="traceLevel"></param>
        /// <returns></returns>
        //[Modules.Core.Permissions]
        public ActionResult Put(string text, TraceLevel traceLevel = TraceLevel.Info)
        {
            _diagnosticsTracingService.Trace(traceLevel, text);

            return Ok();
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
        /// <param name="value">The message.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override IActionResult Put(DiagnosticsTraceRecordDto value)
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
        public override IActionResult Delete(Guid key)
        {
            throw new NotImplementedException();
        }
    }
}
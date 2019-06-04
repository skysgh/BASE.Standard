﻿using System.Linq;
using App.Modules.Core.AppFacade.Controllers.Api.odata.Base;
using App.Modules.Core.AppFacade.Services;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Models.Entities;
using App.Modules.Models.Entities;
using App.Modules.Models.Messages.API.V0100;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Core.AppFacade.Controllers.Api.odata
{

    /// <summary>
    /// Implementation of 
    /// <see cref="IDiagnosticsTracesController"/>
    /// to display DiagnosticsTrace messages
    /// to authorised users.
    /// </summary>
    /// <seealso cref="App.Modules.Core.AppFacade.Controllers.Api.odata.Base.CommonODataControllerBase" />
    [ODataRoutePrefix("DiagnosticsTraces")]
    public class DiagnosticsTracesController
        : GuidIdCommonODataControllerBase<
            ModuleDbContext,
            DiagnosticsTraceRecord,
            DiagnosticsTraceRecordDto>

    {
        /// <summary>Initializes a new instance of the <see cref="DiagnosticsTracesController"/> class.</summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        public DiagnosticsTracesController(
            IControllerCommonServicesService controllerCommonServicesService,
            ModuleDbContext dbContext) :
            base(controllerCommonServicesService, dbContext)
        {

        }

        public IQueryable<DiagnosticsTraceRecordDto> Get()
        {
            //return null;
            return base.InternalGet();
        }


        /// <summary>
        /// Record a Diagnostics Message, if authorised to do so.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="traceLevel"></param>
        /// <returns></returns>
        //[Modules.Core.Permissions]
        public ActionResult Put(string text, TraceLevel traceLevel = TraceLevel.Info)
        {
            _diagnosticsTracingService.Trace(traceLevel, text);

            return new OkResult();
        }
    }
}

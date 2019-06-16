using System.Linq;
using App.Modules.All.AppFacade.Controllers.Api.OData;
using App.Modules.Core.AppFacade.Services;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData
{

    /// <summary>
    /// Controller to return DiagnosticsTrace messages
    /// to authorised users.
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
        /// Initializes a new instance of the <see cref="DiagnosticsTracesController" /> class.
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
        /// Gets a queryable set of
        /// <see cref="DiagnosticsTraceRecordDto"/>
        /// objects.
        /// </summary>
        /// <returns></returns>
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

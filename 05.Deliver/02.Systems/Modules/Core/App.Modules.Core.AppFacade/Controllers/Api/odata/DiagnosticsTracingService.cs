using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Core.AppFacade.Controllers.Api.odata
{
    [Route("api/core/[controller]")]
    public class DiagnosticsTracingService : Base.ModulesODataControllerBase
    {
        public DiagnosticsTracingService(
            IDiagnosticsTracingService diagnosticsTracingService, 
            IPrincipalService principalService) : 
            base(diagnosticsTracingService, principalService)
        {

        }


        
        /// <summary>
        /// Record a Diagnostics Message, if authorised to do so.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="traceLevel"></param>
        /// <returns></returns>
        //[Modules.Core.Permissions]
        public ActionResult Put(string text, Shared.Models.Entities.TraceLevel traceLevel = Shared.Models.Entities.TraceLevel.Info)
        {
            _diagnosticsTracingService.Trace(traceLevel, text);

            return new OkResult();
        }
    }
}

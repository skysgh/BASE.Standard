using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.AppFacade.Controllers.Api.odata.Base;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Design.AppFacade.Controllers.api
{
    [Route(App.Modules.Core.Shared.Constants.All.Apis.BaseODataPath + "design/" + "[controller]")]
    public class ValueController : CommonODataControllerBase
    {
        public ValueController(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService) : base(diagnosticsTracingService, principalService)
        {

        }

        [HttpGet]
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<string>> List()
        {
            return new string[] { "value1", "valueDiagnostics" };
        }

    }
}

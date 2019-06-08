using System.Collections.Generic;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Controllers.Api.OData.Base;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Design.AppFacade.Controllers.Api.Classic
{
    [Route(Apis.BaseODataPath + "design/" + "[controller]")]
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

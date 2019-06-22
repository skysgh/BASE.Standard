// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;
using App.Modules.All.AppFacade.Controllers.Api.OData.Base;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Design.AppFacade.Controllers.Api.Classic
{
    [Route(Apis.BaseODataPath + "design/" + "[controller]")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ValueController : CommonODataControllerBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValueController" /> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        public ValueController(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService)
            : base(diagnosticsTracingService, principalService)
        {
        }

        [HttpGet]
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<string>> List()
        {
            return new[] {"value1", "valueDiagnostics"};
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
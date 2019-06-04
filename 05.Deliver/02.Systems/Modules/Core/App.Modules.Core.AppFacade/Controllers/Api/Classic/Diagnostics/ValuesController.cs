using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Modules.Core.AppFacade.Controllers.Api.Base;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Models.Entities;
using App.Modules.Core.Shared;
using App.Modules.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.Host.Controllers
{
    [Route(App.Modules.Core.Shared.Constants.All.Apis.BasePath + "diagnostics/" + "[controller]")]
    public class DependencyResolutionController : AllModulesApiControllerBase
    {
        private readonly IExampleInfrastructureService _exampleInfrastructureService;

        public DependencyResolutionController(
            IDiagnosticsTracingService diagnosticsTracingService, 
            IPrincipalService principalService,
            IExampleInfrastructureService exampleInfrastructureService, 
            ModuleDbContext dbContext)
            :base(diagnosticsTracingService,principalService)
        {
            _exampleInfrastructureService = exampleInfrastructureService;

            int x = dbContext.Set<DataClassification>().Count();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "valueDiagnostics" };
        }
    }
}

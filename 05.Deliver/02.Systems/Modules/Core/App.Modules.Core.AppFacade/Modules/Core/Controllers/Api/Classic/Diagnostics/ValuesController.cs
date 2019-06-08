using System.Collections.Generic;
using System.Linq;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Core.Controllers.Api.Classic.Diagnostics
{
    [Route(Apis.BasePath + "diagnostics/" + "[controller]")]
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

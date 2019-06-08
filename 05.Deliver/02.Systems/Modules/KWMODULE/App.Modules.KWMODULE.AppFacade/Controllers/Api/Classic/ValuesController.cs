using System.Collections.Generic;
using System.Linq;
using App;
using App.Modules.All.AppFacade.Controllers.Api.Classic;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.KWMODULE.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.KWMODULE.AppFacade.Controllers.Apis.Classic
{
    [Route(App.Modules.All.Shared.Constants.Apis.BasePath + "diagnostics/" + "[controller]")]
    public class DependencyResolutionController : AllModulesApiControllerBase
    {
        private readonly IExampleInfrastructureService _exampleInfrastructureService;

        public DependencyResolutionController(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            IExampleInfrastructureService exampleInfrastructureService,
            ModuleDbContext dbContext)
            : base(diagnosticsTracingService, principalService)
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

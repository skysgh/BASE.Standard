using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Modules.Core.Infrastructure.Data.Db;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.Host.Controllers
{
    [Area("Diagnostics")]
    [Route("api/core/diagnostics/[controller]")]
    [ApiController]
    public class DependencyResolutionController : ControllerBase
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IExampleInfrastructureService _exampleInfrastructureService;

        public DependencyResolutionController(IDiagnosticsTracingService diagnosticsTracingService, IExampleInfrastructureService exampleInfrastructureService, ModuleDbContext dbContext)
        {
            _diagnosticsTracingService = diagnosticsTracingService;
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

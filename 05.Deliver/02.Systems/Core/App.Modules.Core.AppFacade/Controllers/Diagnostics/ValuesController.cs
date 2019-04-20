using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Host.Controllers
{
    [Area("Diagnostics")]
    [Route("api/diagnostics/[controller]")]
    [ApiController]
    public class DependencyResolutionController : ControllerBase
    {
        private readonly IExampleInfrastructureService _exampleInfrastructureService;

        public DependencyResolutionController(IExampleInfrastructureService exampleInfrastructureService)
        {
            _exampleInfrastructureService = exampleInfrastructureService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "valueDiagnostics" };
        }
    }
}

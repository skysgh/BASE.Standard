using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Modules.Core.AppFacade.Controllers.Api.Base;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Core.AppFacade.Controllers.Api
{
    public class Values2Controller : AllModulesApiControllerBase
    {
        private readonly IExampleInfrastructureService _exampleInfrastructureService;

        public Values2Controller(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            IExampleInfrastructureService exampleInfrastructureService)
            : base(diagnosticsTracingService, principalService)
        {
            _exampleInfrastructureService = exampleInfrastructureService;
        }

        // GET api/values
        [HttpGet("")]
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<string>> List()
        {
            return new string[] { "value1", "value2x" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

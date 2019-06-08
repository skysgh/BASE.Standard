using System.Collections.Generic;
using App.Modules.All.AppFacade.Controllers.Api.Classic;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Core.AppFacade.Controllers.Api.Classic
{
    public class Values2Controller : AllModulesApiControllerBase
    {

        public Values2Controller(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService
            )
            : base(diagnosticsTracingService, principalService)
        {
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

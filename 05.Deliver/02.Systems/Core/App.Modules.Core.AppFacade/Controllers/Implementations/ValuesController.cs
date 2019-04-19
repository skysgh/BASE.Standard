using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Values2Controller : ControllerBase
    {
        private readonly IExampleInfrastructureService _exampleInfrastructureService;

        public Values2Controller(IExampleInfrastructureService exampleInfrastructureService)
        {
            _exampleInfrastructureService = exampleInfrastructureService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
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

// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;
using System.Linq;
using App.Modules.All.AppFacade.Controllers.Api.Classic;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Core.AppFacade.Controllers.Api.Classic
{

    /// <summary>
    /// </summary>
    /// <seealso cref="App.Modules.All.AppFacade.Controllers.Api.Classic.AllModulesApiControllerBase" />
    public class Values2Controller : AllModulesApiControllerBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Values2Controller" /> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        public Values2Controller(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService
        )
            : base(diagnosticsTracingService, principalService)
        {
        }

        // GET api/values
        /// <summary>
        ///     TODO: Lists this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<string>> List()
        {

            object o;
            HttpContext.Items.TryGetValue((object)"Finbuckle.MultiTenant.AspNetCore.MultiTenantContext", out o);
            var bbb = HttpContext.Items.FirstOrDefault();
            return new[] {"value1", "value2x"};
        }

        // GET api/values/5
        /// <summary>
        ///     TODO: Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /// <summary>
        ///     TODO
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        /// <summary>
        ///     TODO: Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        /// <summary>
        ///     TODO: Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
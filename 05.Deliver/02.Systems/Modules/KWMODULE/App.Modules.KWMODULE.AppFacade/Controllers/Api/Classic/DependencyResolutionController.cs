using System.Collections.Generic;
using System.Linq;
using App.Modules.All.AppFacade.Controllers.Api.Classic;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.KWMODULE.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.KWMODULE.AppFacade.Controllers.Api.Classic
{
    [Route(All.Shared.Constants.Apis.BasePath + "diagnostics/" + "[controller]")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class DependencyResolutionController : AllModulesApiControllerBase
    {
        private readonly IExampleInfrastructureService _exampleInfrastructureService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DependencyResolutionController" /> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="exampleInfrastructureService">The example infrastructure service.</param>
        /// <param name="dbContext">The database context.</param>
        public DependencyResolutionController(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            IExampleInfrastructureService exampleInfrastructureService,
            ModuleDbContext dbContext)
            : base(diagnosticsTracingService, principalService)
        {
            _exampleInfrastructureService = exampleInfrastructureService;

            var x = dbContext.Set<DataClassification>().Count();
        }

        // GET api/values
        [HttpGet]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public ActionResult<IEnumerable<string>> Get()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return new[] {"value1", "valueDiagnostics"};
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
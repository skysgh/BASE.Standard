// Copyright MachineBrains, Inc. 2019

using System.Linq;
using App.Modules.All.AppFacade.Controllers.Api.Classic;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace App.Modules.Core.AppFacade.Controllers.Api.Classic.Diagnostics
{
    /// <summary>
    ///     TODO
    /// </summary>
    /// <seealso cref="App.Modules.All.AppFacade.Controllers.Api.Classic.AllModulesApiControllerBase" />
    [Route(Apis.BasePath + "diagnostics/" + "[controller]")]
    public class StatusController : AllModulesApiControllerBase
    {
        private readonly ModuleDbContext _dbContext;
        private readonly IDependencyResolutionService _dependencyResolutionService;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="StatusController" /> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="dependencyResolutionService">The dependency resolution service.</param>
        /// <param name="dbContext">The database context.</param>
        public StatusController(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            IDependencyResolutionService dependencyResolutionService,
            ModuleDbContext dbContext)
            : base(diagnosticsTracingService, principalService)
        {
            _dependencyResolutionService = dependencyResolutionService;
            _dbContext = dbContext;
        }

        /// <summary>
        ///     TODO: Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get(string id = "")
        {
            id = id.ToLower();
            switch (id)
            {
                case "dbcontext":
                    return CheckDbConnection();
                case "web":
                default:
                    return Ok($"{TraceLevel.Info}: Website online.");
            }
        }


        /// <summary>
        ///     TODO: Checks the routes.
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckRoutes()
        {
            return _dependencyResolutionService.GetAllInstances<IRouteBuilder>().Count() > 0
                ? Ok($"{TraceLevel.Info}: More than one Mvc/Api Route registered.")
                : StatusCode(500, "Module Routes not found.");
        }


        private ActionResult CheckODataModels()
        {
            try
            {
                var x = _dbContext.Set<DataClassification>().Count();
                return Ok($"{TraceLevel.Info}: Database online.");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        private ActionResult CheckDbConnection()
        {
            try
            {
                var x = _dbContext.Set<DataClassification>().Count();
                return Ok($"{TraceLevel.Info}: Database online.");
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
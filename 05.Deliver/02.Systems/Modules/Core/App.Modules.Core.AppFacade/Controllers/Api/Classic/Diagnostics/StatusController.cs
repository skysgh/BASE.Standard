using App.Modules.Core.AppFacade.Controllers.Api.Base;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using App.Modules.Models.Entities;
using App.Modules.Core.Models.Entities;

namespace App.Modules.Core.AppFacade.Controllers.Api.Diagnostics
{
    [Route(App.Modules.Core.Shared.Constants.All.Apis.BasePath + "diagnostics/"+"[controller]")]
    public class StatusController : AllModulesApiControllerBase
    {
        private readonly IDependencyResolutionService _dependencyResolutionService;
        private readonly ModuleDbContext _dbContext;

        public StatusController(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            IDependencyResolutionService dependencyResolutionService,
            ModuleDbContext dbContext)
            : base(diagnosticsTracingService,principalService)
        {
            _dependencyResolutionService = dependencyResolutionService;
            _dbContext = dbContext;

        }

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

        public ActionResult CheckRoutes()
        {
            return (_dependencyResolutionService.GetAllInstances<IRouteBuilder>().Count() > 0)
                ? Ok($"{TraceLevel.Info}: More than one Mvc/Api Route registered.")
                : StatusCode(500, "Module Routes not found.");
        }



        private ActionResult CheckODataModels()
        {
            try
            {

                int x = _dbContext.Set<DataClassification>().Count();
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
                int x = _dbContext.Set<DataClassification>().Count();
                return Ok($"{TraceLevel.Info}: Database online.");
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}

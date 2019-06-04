using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.AppFacade.Controllers.Api
{
    public class DbController
    {
        public DbController(IDependencyResolutionService dependencyResolutionService)
        {
            _dependencyResolutionService = dependencyResolutionService;
        }

        IDependencyResolutionService _dependencyResolutionService;

        public void Seed(string module)
        {
            var dbContext = _dependencyResolutionService.GetInstance<DbContext>(module);

            ((ModuleDbContextBase)dbContext).EnsureMutableDataSeeded();

        }
    }
}

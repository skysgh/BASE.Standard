using App.Modules.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.All.Infrastructure.Data.Db.Contexts;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IAppDbContextManagementService : IInfrastructureService
    {
        void Register(ModuleDbContextBase dbContext);

        DbContext[] DbContexts { get; }

        void SaveChanges();

    }
}

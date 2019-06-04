using App.Modules.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IAppDbContextManagementService : IModuleSpecificService
    {
        void Register(ModuleDbContextBase dbContext);

        DbContext[] DbContexts { get; }

        void SaveChanges();

    }
}

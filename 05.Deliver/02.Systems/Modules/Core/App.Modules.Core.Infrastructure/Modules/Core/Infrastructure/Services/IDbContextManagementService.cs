// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Data.Db.Contexts;
using App.Modules.All.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IAppDbContextManagementService : IInfrastructureService
    {
        DbContext[] DbContexts { get; }
        void Register(ModuleDbContextBase dbContext);

        void SaveChanges();
    }
}
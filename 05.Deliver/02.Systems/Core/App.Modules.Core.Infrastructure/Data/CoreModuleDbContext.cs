using App.Modules.Core.Infrastructure.Data;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Infrastructure.Data
{
    public class CoreModuleDbContext : AppDbContextBase
    {
        public DbSet<ExampleModel> Examples;

        public CoreModuleDbContext(IAppDbContextManagementService appDbContextManagementService, DbContextOptions<AppDbContextBase> options) : base(appDbContextManagementService, options)
        {
        }

        public CoreModuleDbContext(IAppDbContextManagementService appDbContextManagementService) : base(appDbContextManagementService)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

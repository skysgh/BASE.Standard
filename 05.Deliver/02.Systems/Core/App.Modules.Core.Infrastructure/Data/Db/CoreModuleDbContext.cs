using App.Modules.Core.Infrastructure.Data;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.Extensions.Configuration;

namespace App.Modules.Core.Infrastructure.Data.Db
{
    public class CoreModuleDbContext : ModuleDbContextBase
    {






        public DbSet<DataClassification> DataClassifications;
        //public DbSet<ExampleModel> Examples;

        public CoreModuleDbContext(IConfiguration configuration, IAppDbContextManagementService appDbContextManagementService, DbContextOptions<ModuleDbContextBase> options) : base(configuration, appDbContextManagementService, options)
        {
        }

        public CoreModuleDbContext(IConfiguration configuration, IAppDbContextManagementService appDbContextManagementService) : base(configuration, appDbContextManagementService)
        {
        }
        public CoreModuleDbContext(DbContextOptions options) : base(options)
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

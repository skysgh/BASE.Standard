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
    /// <summary>
    /// This Module's specific <see cref="DbContext"/>.
    /// <para>
    /// Note that it doesn't do much beyond reusing base 
    /// functionality within <see cref="ModuleDbContextBase"/>
    /// which ensures the name of the DbContext is specific 
    /// to the Module Name (eg: 'Core' + 'DbContext' = 'CoreDbContext')
    /// and that it searches for implementations of 
    /// <see cref="IHasAppModuleDbContextModelBuilderInitializer"/>
    /// to create this Module's Database, and the searches for
    /// <see cref="IHasAppModuleDbContextSeedInitializer"/> to seed 
    /// the database if and as required.
    /// </para>
    /// 
    /// </summary>
    public class ModuleDbContext : ModuleDbContextBase
    {
        public DbSet<DataClassification> DataClassifications;
        //public DbSet<ExampleModel> Examples;

        public ModuleDbContext(IConfiguration configuration, IAppDbContextManagementService appDbContextManagementService, DbContextOptions<ModuleDbContextBase> options)
            : 
            base(configuration, appDbContextManagementService, options)
        {
        }

        public ModuleDbContext(IConfiguration configuration, IAppDbContextManagementService appDbContextManagementService)
            : base(configuration, appDbContextManagementService)
        {
        }

        /// <summary>
        /// <para>
        /// Note:
        /// Whereas the other constructors are invoked during run time, 
        /// this contructor will be called by the 
        /// <see cref="ModuleDbContextFactory"/>,
        /// which is invoked when the 'dotnet ef' commands are issued 
        /// from the command line (eg, for Migrations).
        /// </para>
        /// </summary>
        /// <param name="options"></param>
        public ModuleDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// 
        /// <para>
        /// Note:
        /// The override is not strictly required -- it's just here
        /// to bring attention to the work being done in the base class.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // The override is not strictly required -- it's just here
            // to bring attention to the work being done in the base class.
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// 
        /// <para>
        /// Note:
        /// The override is not strictly required -- it's just here
        /// to bring attention to the work being done in the base class.
        /// </para>
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

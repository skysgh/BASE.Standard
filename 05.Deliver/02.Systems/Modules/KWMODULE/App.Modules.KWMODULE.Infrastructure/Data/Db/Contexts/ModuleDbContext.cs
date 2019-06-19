using App.Modules.All.Infrastructure.Data.Db.Contexts;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Seeding.MutableData;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Modules.KWMODULE.Infrastructure.Data.Db.Contexts
{
    /// <summary>
    /// This Module's specific <see cref="DbContext"/>.
    /// <para>
    /// Note that it doesn't do much beyond reusing base 
    /// functionality within <see cref="ModuleDbContextBase"/>
    /// which ensures the name of the DbContext is specific 
    /// to the Module Name (eg: 'Core' + 'DbContext' = 'CoreDbContext')
    /// and that it searches for implementations of 
    /// <see cref="IHasModuleSpecificDbContextModelBuilderSchemaInitializer"/>
    /// to create this Module's Database, and the searches for
    /// <see cref="IHasModuleSpecificDbContextMutableDataSeedingInitializer"/> to seed 
    /// the database if and as required.
    /// </para>
    /// 
    /// </summary>
    public class ModuleDbContext : ModuleDbContextBase
    {
        //public DbSet<DataClassification> DataClassifications;
        //public DbSet<ExampleModel> Examples;

        
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleDbContextBase"/> class.
        /// </summary>
        public ModuleDbContext(
            IConfiguration configuration, 
            IAppDbContextManagementService appDbContextManagementService, 
            DbContextOptions<ModuleDbContextBase> options)
            :
            base(configuration, appDbContextManagementService, options)
        {
        }

        /// <summary>
        /// This is the constructor invoked by the system's dependency injector/creator.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="appDbContextManagementService"></param>
        public ModuleDbContext(
             IConfiguration configuration, 
             IAppDbContextManagementService appDbContextManagementService)
            : base(configuration, appDbContextManagementService)
        {
        }

        /// <summary>
        /// <para>
        /// Note:
        /// Whereas the other constructors are invoked during run time, 
        /// this constructor will be called by the 
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
        /// Initializes a new instance of the <see cref="ModuleDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        protected ModuleDbContext(DbContextOptions<ModuleDbContext> options) : base(options)
        {

            // Does not need Migration to be kicked off (should not) 
            // Nor Seeding.
            // So do not invoke Initialize() from here.
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

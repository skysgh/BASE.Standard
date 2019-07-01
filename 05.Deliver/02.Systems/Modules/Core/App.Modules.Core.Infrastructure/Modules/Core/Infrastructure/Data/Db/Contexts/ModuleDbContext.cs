// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Data.Db.Contexts;
using App.Modules.All.Infrastructure.Data.Db.Seeding.MutableData;
using App.Modules.Core.Infrastructure.Data.Db.ConfigurationStatus;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages;
using LamarCodeGeneration.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Modules.Core.Infrastructure.Data.Db.Contexts
{
    /// <summary>
    ///     This Module's specific <see cref="DbContext" />.
    ///     <para>
    ///         Note that it doesn't do much beyond reusing base
    ///         functionality within <see cref="ModuleDbContextBase" />
    ///         which ensures the name of the DbContext is specific
    ///         to the Module Name (eg: 'Core' + 'DbContext' = 'CoreDbContext')
    ///         and that it searches for implementations of
    ///         <see cref="IHasAppModuleDbContextModelBuilderInitializer" />
    ///         to create this Module's Database, and the searches for
    ///         <see cref="IHasModuleSpecificDbContextMutableDataSeedingInitializer" /> to seed
    ///         the database if and as required.
    ///     </para>
    /// </summary>
    public class ModuleDbContext : ModuleDbContextBase
    {
        public DbSet<DataClassification> DataClassifications;
        private readonly DbDatabaseConfigurationStatus _configurationStatus;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleDbContextBase" /> class.
        /// <para>
        /// This is the constructor invoked from unit Tests.
        /// </para>
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="appDbContextManagementService">The application database context management service.</param>
        /// <param name="options">The options.</param>
        public ModuleDbContext(IConfiguration configuration,
            IAppDbContextManagementService appDbContextManagementService, 
            DbContextOptions<ModuleDbContextBase> options)
            :
            base(
                configuration, 
                appDbContextManagementService, 
                options)
        {
        }

        /// <summary>
        /// This is the constructor invoked by the system's dependency injector/creator
        /// at run time (not Unit Tests)
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="configurationStatus">The configuration status.</param>
        /// <param name="appDbContextManagementService">The application database context management service.</param>
        public ModuleDbContext(
            IConfiguration configuration,
            DbDatabaseConfigurationStatus configurationStatus,
            IAppDbContextManagementService appDbContextManagementService
            )
            : base(configuration, 
                appDbContextManagementService)
        {
            this._configurationStatus = configurationStatus;
        }

        /// <summary>
        /// This is the constructor invoked
        /// by a subclass of
        /// <see cref="ModuleDbContextFactoryBase{TModuleDbContext}"/>
        /// when invoked from a
        /// commandline when making migrations
        /// using the
        /// <![CDATA[
        /// dotnet ef migrations ...etc...
        /// ]]>
        /// command.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="options">The options.</param>
        public ModuleDbContext(
            IConfiguration configuration,
            DbContextOptions options) 
            : base(configuration, options)
        {
        }

        protected ModuleDbContext(IConfiguration configuration,
            DbContextOptions<ModuleDbContext> options) : base(configuration, options)
        {
            // Does not need Migration to be kicked off (should not) 
            // Nor Seeding.
            // So do not invoke Initialize() from here.
        }

        
        /// <summary>
        ///     <para>
        ///         Note:
        ///         The override is not strictly required -- it's just here
        ///         to bring attention to the work being done in the base class.
        ///     </para>
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // The override is not strictly required -- it's just here
            // to bring attention to the work being done in the base class.
            base.OnConfiguring(optionsBuilder);


        }

        /// <summary>
        ///     <para>
        ///         Note:
        ///         The override is not strictly required -- it's just here
        ///         to bring attention to the work being done in the base class.
        ///     </para>
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
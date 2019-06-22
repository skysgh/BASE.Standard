// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Diagrams.PlantUml.Uml;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData;
using App.Modules.All.Infrastructure.Data.Db.Seeding.MutableData;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using LamarCodeGeneration.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace App.Modules.All.Infrastructure.Data.Db.Contexts
{
    /// <summary>
    ///     This Module's specific <see cref="DbContext" />.
    ///     <para>
    ///         Note that it doesn't do much beyond reusing base
    ///         functionality within <see cref="ModuleDbContextBase" />
    ///         which ensures the name of the DbContext is specific
    ///         to the Module Name (eg: 'Core' + 'DbContext' = 'CoreDbContext')
    ///         and that it searches for implementations of
    ///         <see cref="IHasModuleSpecificDbContextModelBuilderSchemaInitializer" />
    ///         to create this Module's Database, and the searches for
    ///         <see cref="IHasModuleSpecificDbContextMutableDataSeedingInitializer" /> to seed
    ///         the database if and as required.
    ///     </para>
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public abstract class ModuleDbContextBase : DbContext
    {
        private static IConfiguration _configuration;


        private static readonly List<Type> Migrated = new List<Type>();
        private static readonly List<Type> Seeded = new List<Type>();

        private readonly IAppDbContextManagementService _appDbContextManagementService;
        private readonly bool _isJointTable;
        private string _defaultConnectionString;
        private string _defaultConnectionStringName;

        /// <summary>
        ///     The migrations applied
        /// </summary>
        private bool _migrationsApplied;

        private string _moduleName;


        private bool _okToSave;


        /// <summary>
        ///     Initializes a new instance of the <see cref="ModuleDbContextBase" /> class.
        ///     <para>
        ///         This is the Constructor called by <see cref="ModuleDbContextFactory" />,
        ///         which is invoked when one invokes 'dotnet' frome the commandline.
        ///     </para>
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="appDbContextManagementService">The application database context management service.</param>
        /// <param name="options">The options.</param>
        protected ModuleDbContextBase(
            IConfiguration configuration,
            IAppDbContextManagementService appDbContextManagementService,
            DbContextOptions<ModuleDbContextBase> options)
            : base(options)
        {
            // _configuration = configuration;

            _appDbContextManagementService = appDbContextManagementService;

            Initialize();
        }


        /// <summary>
        ///     This is the constructor invoked by the system's dependency injector/creator.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="appDbContextManagementService">The application database context management service.</param>
        /// <param name="isJointTable">if set to <c>true</c> [initialize model].</param>
        protected ModuleDbContextBase(
            IConfiguration configuration,
            IAppDbContextManagementService appDbContextManagementService,
            bool isJointTable = false)
        {
            _isJointTable = isJointTable;
            _migrationsApplied = !isJointTable;

            _configuration = configuration;
            _appDbContextManagementService = appDbContextManagementService;
            Initialize();
        }

        /// <summary>
        ///     This is the constructor invoked by the system's dependency injector/creator.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="appDbContextManagementService"></param>
        protected ModuleDbContextBase(
            IConfiguration configuration,
            IAppDbContextManagementService appDbContextManagementService)
        {
            _configuration = configuration;
            _appDbContextManagementService = appDbContextManagementService;

            Initialize();
        }

        /// <summary>
        ///     This is the constructor invoked from commandline when making migrations
        ///     using the dotnet ef migrations etc...command.
        /// </summary>
        /// <param name="options"></param>
        protected ModuleDbContextBase(DbContextOptions options) : base(options)
        {
            // Does not need Migration to be kicked off (should not) 
            // Nor Seeding.
            // So do not invoke Initialize() from here.
        }


        /// <summary>
        ///     Initializes a new instance of the <see cref="ModuleDbContextBase" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        protected ModuleDbContextBase(DbContextOptions<ModuleDbContextBase> options) : base(options)
        {
            // Does not need Migration to be kicked off (should not) 
            // Nor Seeding.
            // So do not invoke Initialize() from here.
        }

        /// <summary>
        ///     Gets or sets the name of the logical module.
        ///     <para>
        ///         Will be Core, Foo, etc.
        ///     </para>
        /// </summary>
        protected string ModuleName
        {
            get => _moduleName ?? (_moduleName = Module.Id(GetType()));
            set => _moduleName = value;
        }


        private static IConfiguration Config
        {
            get
            {
                var result = _configuration ?? (_configuration = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", true, true).Build());
                return result;
            }
            set => _configuration = value;
        }

        /// <summary>
        ///     Returns the default name of the ConnectionString
        ///     used within config settings.
        ///     <para>
        ///         Used by <see cref="DefaultConnectionString" />
        ///         to find itself in the Config file.
        ///     </para>
        /// </summary>
        public string DefaultConnectionStringName =>
            _defaultConnectionStringName
            ?? (_defaultConnectionStringName = $"{ModuleName}{GetType().Name}");


        /// <summary>
        ///     Gets the default connection string
        ///     for this DbContext.
        /// </summary>
        /// <value>
        ///     The default connection string.
        /// </value>
        public string DefaultConnectionString =>
            _defaultConnectionString
            ?? (_defaultConnectionString = Config
                .GetConnectionString(DefaultConnectionStringName));

        /// <summary>
        ///     Prepares to save.
        /// </summary>
        public void PrepareToSave()
        {
            _okToSave = true;
        }


        /// <summary>
        ///     Invoked from Constructor.
        /// </summary>
        private void Initialize()
        {
            _appDbContextManagementService.Register(this);
            if (_isJointTable)
            {
                return;
            }

            EnsureDbContextIsMigrated();
            // Old school seeding:
            EnsureMutableDataIsSeeded();
        }

        //protected AppModuleDbContextBase()
        //{
        //    //Old:
        //    //Database.CommandTimeout = System.Math.Max(dbConnection.ConnectionTimeout, 30);
        //    //this.Database.Log = s => Trace.WriteLine(s);
        //}

        /// <summary>
        ///     Note: default behaviour is that it is not called by constructor by default.
        ///     But is called by Migrate.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DefaultConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        ///     Override this method to further configure the model that was discovered by convention from the entity types
        ///     exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting
        ///     model may be cached
        ///     and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">
        ///     The builder being used to construct the model for this context. Databases (and other extensions) typically
        ///     define extension methods on this object that allow you to configure aspects of the model that are specific
        ///     to a given database.
        /// </param>
        /// <remarks>
        ///     If a model is explicitly set on the options for this context (via
        ///     <see
        ///         cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />
        ///     )
        ///     then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var t = GetType().Name;

            InvokeDatabaseModelBuilders(modelBuilder);

            IgnoreCoreEntitiesIfThisModuleIsNotCore(modelBuilder);
            IMutableEntityType[] check = modelBuilder.Model.GetEntityTypes().ToArray();

            if (_isJointTable)
            {
                IMutableEntityType[] check2 = check;
            }

            if (!_isJointTable)
            {
                // The way Seeding is done has changed since .NET Framework
                // So don't invoke optional seeding at this point (Immutable data is seen as part of the Model);
                InvokeDatabaseModelBuildersInThisAssembliesForSeedingImmutableData(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        ///     Invokes the database model builders.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected virtual void InvokeDatabaseModelBuilders(ModelBuilder modelBuilder)
        {
            InvokeCoreDatabaseModelBuildersInThisAssembly(modelBuilder);
            if (_isJointTable)
            {
                InvokeDatabaseModelBuildersInCoreAssembly(modelBuilder);
            }
        }

        /// <summary>
        ///     Invokes the database model builders in core logical module.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected virtual void InvokeDatabaseModelBuildersInCoreAssembly(ModelBuilder modelBuilder)
        {
            var type = typeof(ModuleDbContextBase);
            InvokeDatabaseModelBuildersInAssembly(modelBuilder, type);
        }

        /// <summary>
        ///     Invokes the core database model builders in this assembly.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected virtual void InvokeCoreDatabaseModelBuildersInThisAssembly(ModelBuilder modelBuilder)
        {
            var type = GetType();

            InvokeDatabaseModelBuildersInAssembly(modelBuilder, type);
        }

        /// <summary>
        ///     Invokes the database model builders in assembly.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        /// <param name="type">The type.</param>
        protected virtual void InvokeDatabaseModelBuildersInAssembly(ModelBuilder modelBuilder, Type type)
        {
            Type[] modelBuilderTypesA = type.Assembly.GetTypes()
                .Where(x =>
                    x.IsConcrete()
                    && typeof(IHasModuleSpecificDbContextModelBuilderSchemaInitializer).IsAssignableFrom(x)
                )
                .SortByOrderByAttribute();

            modelBuilderTypesA.ForEach(x =>
                ((IHasModuleSpecificDbContextModelBuilderSchemaInitializer)
                    Activator.CreateInstance(x)
                )
                .DefineSchema(modelBuilder));
            //}

            // This contract was registered for this module only
            // from within the Module's Infrastructure ServiceRegistry
            Type[] modelBuilderTypes = GetType().Assembly.GetTypes()
                .Where(x =>
                    x.IsConcrete()
                    && typeof(IHasModuleSpecificDbContextModelBuilderSchemaInitializer).IsAssignableFrom(x)
                )
                .SortByOrderByAttribute();

            modelBuilderTypes.ForEach(x =>
                ((IHasModuleSpecificDbContextModelBuilderSchemaInitializer)
                    Activator.CreateInstance(x)
                )
                .DefineSchema(modelBuilder));
        }

        /// <summary>
        ///     Ignores the core entities if this module is not core.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected virtual void IgnoreCoreEntitiesIfThisModuleIsNotCore(ModelBuilder modelBuilder)
        {
            if (_isJointTable)
            {
                return;
            }

            var type = typeof(Session);
            if (GetType().IsSameLogicalModuleAs(type))
            {
                return;
            }

            IgnoreCoreEntitiesInModule(modelBuilder, type);
        }

        /// <summary>
        ///     Ignores the core entities if this module is not core.
        ///     <para>
        ///         This is really important when you create a <see cref="DbContext" />
        ///         in a module. Every module other than Core has to pull ensure that
        ///         any Core entities it's Modules (eg: SchoolModule entities)
        ///         are Navigating to (maybe Core.User) don't cause the
        ///         SchoolModule's DbContext
        ///         to try to create those tables (they've already been created, in the
        ///         Core Schema).
        ///     </para>
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        /// <param name="type">The type.</param>
        protected virtual void IgnoreCoreEntitiesInModule(ModelBuilder modelBuilder, Type type)
        {
            var entityNamespace = type.Namespace;
            if (entityNamespace.IsNullOrEmpty())
            {
                return;
            }

            Type[] modelBuilderTypes = type.Assembly.GetTypes()
                .Where(x =>
                    x.IsConcrete()
                    && (x.Namespace ?? "").StartsWith(entityNamespace)
                ).ToArray();

            modelBuilderTypes.ForEach(x =>
                //new DefaultTableAndSchemaNamingConvention().Define<>()
                modelBuilder.Ignore(x)
            );
        }


        /// <summary>
        ///     Invokes the database model builders in this assemblies for seeding immutable data.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected virtual void InvokeDatabaseModelBuildersInThisAssembliesForSeedingImmutableData(
            ModelBuilder modelBuilder)
        {
            // This contract was registered for this module only
            // from within the Module's Infrastructure ServiceRegistry
            Type[] modelBuilderTypes = GetType().Assembly.GetTypes()
                .Where(x =>
                    x.IsConcrete()
                    && typeof(IHasModuleSpecificDbContextModelBuilderImmutableDataSeedingInitializer)
                        .IsAssignableFrom(x)
                    && x.IsSameLogicalModuleAs(GetType())
                )
                .SortByOrderByAttribute();

            modelBuilderTypes.ForEach(x =>
                ((IHasModuleSpecificDbContextModelBuilderImmutableDataSeedingInitializer)
                    Activator.CreateInstance(x)
                )
                .DefineImmutableData(modelBuilder));
        }


        private void EnsureDbContextIsMigrated()
        {
            var type = GetType();
            if (Migrated.Contains(type))
            {
                return;
            }

            lock (this)
            {
                Database.Migrate();
                Migrated.Add(type);
            }
        }

        /// <summary>
        ///     Ensures the mutable (eg: Demo data) data is seeded.
        /// </summary>
        public virtual void EnsureMutableDataIsSeeded()
        {
            var type = GetType();
            if (Seeded.Contains(type))
            {
                return;
            }

            lock (this)
            {
                InvokeDatabaseSeedersInThisAssembly();
                Seeded.Add(type);
            }
        }

        /// <summary>
        ///     Invokes the database seeders in this assembly.
        /// </summary>
        protected virtual void InvokeDatabaseSeedersInThisAssembly()
        {
            Type[] seederTypes = GetType().Assembly.GetTypes()
                    .Where(x =>
                        x.IsConcrete()
                        && typeof(IHasModuleSpecificDbContextMutableDataSeedingInitializer)
                            .IsAssignableFrom(x)
                        && x.IsSameLogicalModuleAs(GetType())
                    )
                    .SortByOrderByAttribute()
                ;

            seederTypes.ForEach(x =>
            {
                ((IHasModuleSpecificDbContextMutableDataSeedingInitializer) Activator.CreateInstance(x))
                    .SeedMutableData(this);
            });
        }


        /// <summary>
        ///     Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>
        ///     The number of state entries written to the database.
        /// </returns>
        /// <remarks>
        ///     This method will automatically call
        ///     <see cref="M:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges" /> to discover any
        ///     changes to entity instances before saving to the underlying database. This can be disabled via
        ///     <see cref="P:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled" />.
        /// </remarks>
        public override int SaveChanges()
        {
            if (!_okToSave)
            {
                return 0;
            }

            var hasChanges = base.ChangeTracker.HasChanges();
            var changed = base.SaveChanges();
            var hasChanges2 = base.ChangeTracker.HasChanges();

            _okToSave = false;
            return changed;
        }

        /// <summary>
        ///     Saves all changes made in this context to the database.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">
        ///     Indicates whether <see cref="M:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AcceptAllChanges" /> is
        ///     called after the changes have
        ///     been sent successfully to the database.
        /// </param>
        /// <returns>
        ///     The number of state entries written to the database.
        /// </returns>
        /// <remarks>
        ///     This method will automatically call
        ///     <see cref="M:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges" /> to discover any
        ///     changes to entity instances before saving to the underlying database. This can be disabled via
        ///     <see cref="P:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled" />.
        /// </remarks>
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            if (!_okToSave)
            {
                return 0;
            }

            //CreatedByPrincipalId = "...",
            //CreatedOnUtc = DateTimeOffset.UtcNow,
            //DeletedByPrincipalId = null,
            //DeletedOnUtc = null,
            //LastModifiedByPrincipalId = "...",
            //LastModifiedOnUtc = DateTimeOffset.UtcNow,
            var hasChanges = base.ChangeTracker.HasChanges();
            int changed;
            try
            {
                changed = base.SaveChanges(acceptAllChangesOnSuccess);
            }
            catch (Exception e)
            {
                changed = 0;
#pragma warning disable IDE0059 // Value assigned to symbol is never used
                var s = e.Message;
#pragma warning restore IDE0059 // Value assigned to symbol is never used
            }

            var hasChanges2 = base.ChangeTracker.HasChanges();

            _okToSave = false;
            return changed;
        }

        /// <summary>
        ///     Asynchronously saves all changes made in this context to the database.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">
        ///     Indicates whether <see cref="M:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AcceptAllChanges" /> is
        ///     called after the changes have
        ///     been sent successfully to the database.
        /// </param>
        /// <param name="cancellationToken">
        ///     A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the
        ///     task to complete.
        /// </param>
        /// <returns>
        ///     A task that represents the asynchronous save operation. The task result contains the
        ///     number of state entries written to the database.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         This method will automatically call
        ///         <see cref="M:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges" /> to discover any
        ///         changes to entity instances before saving to the underlying database. This can be disabled via
        ///         <see cref="P:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled" />.
        ///     </para>
        ///     <para>
        ///         Multiple active operations on the same context instance are not supported.  Use 'await' to ensure
        ///         that any asynchronous operations have completed before calling another method on this context.
        ///     </para>
        /// </remarks>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            if (_okToSave)
            {
                ;
            }

            _okToSave = false;
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        ///     Asynchronously saves all changes made in this context to the database.
        /// </summary>
        /// <param name="cancellationToken">
        ///     A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the
        ///     task to complete.
        /// </param>
        /// <returns>
        ///     A task that represents the asynchronous save operation. The task result contains the
        ///     number of state entries written to the database.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         This method will automatically call
        ///         <see cref="M:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges" /> to discover any
        ///         changes to entity instances before saving to the underlying database. This can be disabled via
        ///         <see cref="P:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled" />.
        ///     </para>
        ///     <para>
        ///         Multiple active operations on the same context instance are not supported.  Use 'await' to ensure
        ///         that any asynchronous operations have completed before calling another method on this context.
        ///     </para>
        /// </remarks>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (_okToSave)
            {
                return Task.FromResult(0);
            }

            _okToSave = false;
            return base.SaveChangesAsync(cancellationToken);
        }


        //// Intercept all saves in order to clean up loose ends
        //public override int SaveChanges()
        //{
        //    var dbContextPreCommitService =
        //        AppDependencyLocator.Current.GetInstance<IDbContextPreCommitService>();

        //    dbContextPreCommitService.PreProcess(this);

        //    return base.SaveChanges();
        //}

        //public override Task<int> SaveChangesAsync()
        //{
        //    var dbContextPreCommitService =
        //        AppDependencyLocator.Current.GetInstance<IDbContextPreCommitService>();

        //    dbContextPreCommitService.PreProcess(this);

        //    return base.SaveChangesAsync();
        //}
    }
}
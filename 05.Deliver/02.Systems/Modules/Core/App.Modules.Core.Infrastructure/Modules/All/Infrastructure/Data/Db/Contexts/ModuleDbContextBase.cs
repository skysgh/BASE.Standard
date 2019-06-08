﻿using System;
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
using Microsoft.Extensions.Configuration;

namespace App.Modules.All.Infrastructure.Data.Db.Contexts
{
    public abstract class ModuleDbContextBase : DbContext
    {

        protected string ModuleName
        {
            get { return _moduleName ?? (_moduleName = Module.Id(GetType())); }
            set { _moduleName = value; }
        }
        private string _moduleName;


        private static IConfiguration Config
        {
            get
            {
                var result = _configuration ?? (_configuration = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json", true, true).Build());
                return result;
            }
            set { _configuration = value; }
        }
        private static IConfiguration _configuration;


        private static List<Type> Migrated = new List<Type>();
        private static List<Type> Seeded = new List<Type>();

        /// <summary>
        /// Returns the default name of the ConnectionString
        /// used within config settings.
        /// <para>
        /// Used by <see cref="DefaultConnectionString"/>
        /// to find itself in the Config file.
        /// </para>
        /// </summary>
        public string DefaultConnectionStringName
        {
            get
            {
                // Note that the default Name combines the
                // Module Name + Type Name and comes out
                // something like 'CoreDbContext':
                return _defaultConnectionStringName
                       ?? (_defaultConnectionStringName = $"{this.ModuleName}{GetType().Name}");
            }
        }
        private string _defaultConnectionStringName;



        /// <summary>
        /// Gets the default connection string
        /// for this DbContext.
        /// </summary>
        /// <value>
        /// The default connection string.
        /// </value>
        public string DefaultConnectionString
        {
            get
            {
                return _defaultConnectionString
                       ?? (_defaultConnectionString = Config
                           .GetConnectionString(DefaultConnectionStringName));
            }
        }
        private string _defaultConnectionString;


        bool _okToSave = false;
        public void PrepareToSave()
        {
            _okToSave = true;
        }

        IAppDbContextManagementService _appDbContextManagementService;
        private readonly bool _isJointTable;
        protected bool _migrationsApplied;


        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleDbContextBase"/> class.
        /// <para>
        /// This is the Constructor called by <see cref="ModuleDbContextFactory"/>,
        /// which is invoked when one invokes 'dotnet' frome the commandline.
        /// </para>
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
        /// This is the constructor invoked by the system's dependency injector/creator.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="appDbContextManagementService">The application database context management service.</param>
        /// <param name="isJointTable">if set to <c>true</c> [initialize model].</param>
        protected ModuleDbContextBase(
            IConfiguration configuration,
            IAppDbContextManagementService appDbContextManagementService,
            bool isJointTable = false)
            : base()
        {
            this._isJointTable = isJointTable;
            _migrationsApplied = !isJointTable;

            _configuration = configuration;
            _appDbContextManagementService = appDbContextManagementService;
            Initialize();
        }

        /// <summary>
        /// This is the constructor invoked by the system's dependency injector/creator.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="appDbContextManagementService"></param>
        protected ModuleDbContextBase(
            IConfiguration configuration,
            IAppDbContextManagementService appDbContextManagementService)
            : base()
        {
            _configuration = configuration;
            _appDbContextManagementService = appDbContextManagementService;

            Initialize();
        }

        /// <summary>
        /// This is the constructor invoked from commandline when making migrations
        /// using the dotnet ef migrations etc...command.
        /// </summary>
        /// <param name="options"></param>
        protected ModuleDbContextBase(DbContextOptions options) : base(options)
        {
            // Does not need Migration to be kicked off (should not) 
            // Nor Seeding.
            // So do not invoke Initialize() from here.
        }


        protected ModuleDbContextBase(DbContextOptions<ModuleDbContextBase> options) : base(options)
        {
            // Does not need Migration to be kicked off (should not) 
            // Nor Seeding.
            // So do not invoke Initialize() from here.
        }


        /// <summary>
        /// Invoked from Constructor.
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
            EnsureMutableDataSeeded();
        }

        //protected AppModuleDbContextBase()
        //{
        //    //Old:
        //    //Database.CommandTimeout = System.Math.Max(dbConnection.ConnectionTimeout, 30);
        //    //this.Database.Log = s => Trace.WriteLine(s);
        //}

        /// <summary>
        /// Not: default behaviour is that it is not called by constructor by default.
        /// But is called by Migrate.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DefaultConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var t = this.GetType().Name;

            InvokeDatabaseModelBuilders(modelBuilder);

            IgnoreCoreEntitiesIfThisModuleIsNotCore(modelBuilder);
            var check = modelBuilder.Model.GetEntityTypes().ToArray();

            if (_isJointTable)
            {
                var check2 = check;
            }
            if (!_isJointTable)
            {

                // The way Seeding is done has changed since .NET Framework
                // So don't invoke optional seeding at this point (Immutable data is seen as part of the Model);
                InvokeDatabaseModelBuildersInThisAssembliesForSeedingImmutableData(modelBuilder);
            }
            base.OnModelCreating(modelBuilder);
        }

        protected virtual void InvokeDatabaseModelBuilders(ModelBuilder modelBuilder)
        {
            InvokeCoreDatabaseModelBuildersInThisAssembly(modelBuilder);
            if (_isJointTable)
            {
                InvokeDatabaseModelBuildersInCoreAssembly(modelBuilder);
            }
        }
        protected virtual void InvokeDatabaseModelBuildersInCoreAssembly(ModelBuilder modelBuilder)
        {
            var type = typeof(ModuleDbContextBase);
            InvokeDatabaseModelBuildersInAssembly(modelBuilder, type);
        }
        protected virtual void InvokeCoreDatabaseModelBuildersInThisAssembly(ModelBuilder modelBuilder)
        {
            var type = this.GetType();
            InvokeDatabaseModelBuildersInAssembly(modelBuilder, type);
        }

        protected virtual void InvokeDatabaseModelBuildersInAssembly(ModelBuilder modelBuilder, Type type)
        {
            var modelBuilderTypesA = type.Assembly.GetTypes()
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
            var modelBuilderTypes = GetType().Assembly.GetTypes()
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

        protected virtual void IgnoreCoreEntitiesIfThisModuleIsNotCore(ModelBuilder modelBuilder)
        {
            if (_isJointTable)
            {
                return;
            }

            var type = typeof(Session);
            if (this.GetType().IsSameLogicalModuleAs(type))
            {
                return;
            }
            IgnoreCoreEntitiesInModule(modelBuilder, type);
        }

        /// <summary>
        /// Ignores the core entities if this module is not core.
        /// <para>
        /// This is really important when you create a <see cref="DbContext"/>
        /// in a module. Every module other than Core has to pull ensure that
        /// any Core entities it's Modules (eg: SchoolModule entities)
        /// are Navigating to (maybe Core.User) don't cause the
        /// SchoolModule's DbContext
        /// to try to create those tables (they've already been created, in the
        /// Core Schema).
        /// </para>
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected virtual void IgnoreCoreEntitiesInModule(ModelBuilder modelBuilder, Type type)
        {

            var entityNamespace = type.Namespace;
            if (entityNamespace.IsNullOrEmpty())
            {
                return;
            }
            var modelBuilderTypes = type.Assembly.GetTypes()
                .Where(x =>
                    x.IsConcrete()
                    && (x.Namespace ?? "").StartsWith(entityNamespace)
                ).ToArray();

            modelBuilderTypes.ForEach(x =>
                //new DefaultTableAndSchemaNamingConvention().Define<>()
                modelBuilder.Ignore(x)
                );
        }




        protected virtual void InvokeDatabaseModelBuildersInThisAssembliesForSeedingImmutableData(ModelBuilder modelBuilder)
        {

            // This contract was registered for this module only
            // from within the Module's Infrastructure ServiceRegistry
            var modelBuilderTypes = GetType().Assembly.GetTypes()
                .Where(x =>
                x.IsConcrete()
                && typeof(IHasModuleSpecificDbContextModelBuilderImmutableDataSeedingInitializer).IsAssignableFrom(x)
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
            Type type = GetType();
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

        public virtual void EnsureMutableDataSeeded()
        {
            Type type = GetType();
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

        protected virtual void InvokeDatabaseSeedersInThisAssembly()
        {
            var seederTypes = GetType().Assembly.GetTypes()
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
                ((IHasModuleSpecificDbContextMutableDataSeedingInitializer)Activator.CreateInstance(x))
                .SeedMutableData(this);
            });
        }



        public override int SaveChanges()
        {

            if (!_okToSave)
            {
                return 0;
            }

            bool hasChanges = base.ChangeTracker.HasChanges();
            var changed = base.SaveChanges();
            bool hasChanges2 = base.ChangeTracker.HasChanges();

            _okToSave = false;
            return changed;
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            if (!_okToSave)
            {
                return 0;
            }

            //CreatedByPrincipalId = "...",
            //CreatedOnUtc = DateTime.UtcNow,
            //DeletedByPrincipalId = null,
            //DeletedOnUtc = null,
            //LastModifiedByPrincipalId = "...",
            //LastModifiedOnUtc = DateTime.UtcNow,
            bool hasChanges = base.ChangeTracker.HasChanges();
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
            bool hasChanges2 = base.ChangeTracker.HasChanges();

            _okToSave = false;
            return changed;
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            if (_okToSave)
            {
                ;
            }
            _okToSave = false;
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
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

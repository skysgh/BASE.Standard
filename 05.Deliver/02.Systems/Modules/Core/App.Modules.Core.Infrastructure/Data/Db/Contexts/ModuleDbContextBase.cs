
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Diagrams.PlantUml.Uml;
using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema;
using App.Modules.Core.Infrastructure.Data.Db.Migrations.Seeding.ImmutableData;
using App.Modules.Core.Infrastructure.Data.Db.Migrations.Seeding.MutableData;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Models.Entities;
using LamarCodeGeneration.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Modules.Core.Infrastructure.Data.Db.Contexts
{
    public abstract class ModuleDbContextBase : DbContext
    {

        protected string ModuleName => Shared.Constants.ModuleSpecific.Module.Id(GetType());

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
        /// </summary>
        public string DefaultConnectionStringName
        {
            get
            {
                // Note that the default Name combines the
                // Module Name + Type Name and comes out
                // something like 'CoreDbContext':
                return _defaultConnectionStringName
                       ?? (_defaultConnectionStringName = $"{ModuleName}{GetType().Name}");
            }
        }
        private string _defaultConnectionStringName;



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


        protected ModuleDbContextBase(IConfiguration configuration, IAppDbContextManagementService appDbContextManagementService, DbContextOptions<ModuleDbContextBase> options) : base(options)
        {


            // _configuration = configuration;
            _appDbContextManagementService = appDbContextManagementService;

            Initialize();
        }


        /// <summary>
        /// This is the constructor invoked by the system's dependency injector/creator.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="appDbContextManagementService"></param>
        protected ModuleDbContextBase(IConfiguration configuration, IAppDbContextManagementService appDbContextManagementService) : base()
        {
            _configuration = configuration;
            _appDbContextManagementService = appDbContextManagementService;

            Initialize();
        }
        /// <summary>
        /// This is the contructor invoked from commandline when making migrations.
        /// </summary>
        /// <param name="options"></param>
        protected ModuleDbContextBase(DbContextOptions options) : base(options)
        {
            // Does not need Migration to be kicked off (should not) 
            // Nor Seeding.
            // So do not invoke Initialize() from here.
        }


        private void Initialize()
        {
            _appDbContextManagementService.Register(this);
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
            InvokeDatabaseModelBuildersInThisAssemblies(modelBuilder);

            IgnoreCoreEntitiesIfThisModuleIsNotCore(modelBuilder);

            // The way Seeding is done has changed since .NET Framework
            // So don't invoke optional seeding at this point (Immutable data is seen as part of the Model);

            InvokeDatabaseModelBuildersInThisAssembliesForSeedingImmutableData(modelBuilder);
        }




        protected virtual void InvokeDatabaseModelBuildersInThisAssemblies(ModelBuilder modelBuilder)
        {

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
            var type = typeof(Session);
            if (this.GetType().IsSameModuleAs(type))
            {
                return;
            }

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

            modelBuilderTypes.ForEach(x => modelBuilder.Ignore(x));
        }



        protected virtual void InvokeDatabaseModelBuildersInThisAssembliesForSeedingImmutableData(ModelBuilder modelBuilder)
        {

            // This contract was registered for this module only
            // from within the Module's Infrastructure ServiceRegistry
            var modelBuilderTypes = GetType().Assembly.GetTypes()
                .Where(x =>
                x.IsConcrete()
                && typeof(IHasModuleSpecificDbContextModelBuilderImmutableDataSeedingInitializer).IsAssignableFrom(x)
                && x.IsSameModuleAs(GetType())
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
                && x.IsSameModuleAs(GetType())
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


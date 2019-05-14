
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using App.Modules.Core.Infrastructure.Initialization.Db;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Implementations;
using LamarCodeGeneration.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Modules.Core.Infrastructure.Data.Db
{
    public abstract class ModuleDbContextBase : DbContext
    {
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

        public string DefaultConnectionStringName
        {
            get
            {
                return _defaultConnectionStringName
                       ?? (_defaultConnectionStringName = this.GetType().Name);
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

            _appDbContextManagementService.Register(this);

            EnsureDbContextIsMigrated();
        }

        private void EnsureDbContextIsMigrated()
        {
            Type type = this.GetType();
            if (Migrated.Contains(type))
            {
                return;
            }
            lock (this)
            {
                this.Database.Migrate();
                Migrated.Add(type);
            }
        }

        protected ModuleDbContextBase(IConfiguration configuration, IAppDbContextManagementService appDbContextManagementService) : base()
        {
            _configuration = configuration;
            _appDbContextManagementService = appDbContextManagementService;
            _appDbContextManagementService.Register(this);
        }
        protected ModuleDbContextBase(DbContextOptions options) : base(options) { }

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
            optionsBuilder.UseSqlServer(this.DefaultConnectionString);

            Assembly thisAssembly = this.GetType().Assembly;

            //_dbContextSchemaModelInitializationService.DefineByReflection(modelBuilder, thisAssembly);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //IDbContextSchemaModelInitializationService dbContextSchemaModelInitializationService =
            //    new DbContextSchemaModelInitializationService();

            InvokeDatabaseModelBuildersInThisAssemblies(modelBuilder);
            InvokeDatabaseSeedersInThisAssembly(modelBuilder);
        }


        private void InvokeDatabaseModelBuildersInThisAssemblies(ModelBuilder modelBuilder)
        {

            // This contract was registered for this module only
            // from within the Module's Infrastructure ServiceRegistry
            var modelBuilderTypes = this.GetType().Assembly.GetTypes()
                .Where(x => (x.IsConcrete() && typeof(IHasAppModuleDbContextModelBuilderInitializer).IsAssignableFrom(x)));

            modelBuilderTypes.ForEach(x =>
            {
                ((IHasAppModuleDbContextModelBuilderInitializer) Activator.CreateInstance(x)).Define(modelBuilder);
            });
        }

        private void InvokeDatabaseSeedersInThisAssembly(ModelBuilder modelBuilder)
        {
            var seederTypes = this.GetType().Assembly.GetTypes()
                .Where(x => (x.IsConcrete() && typeof(IHasAppModuleDbContextSeedInitializer).IsAssignableFrom(x)));

            seederTypes.ForEach(x =>
            {
                ((IHasAppModuleDbContextSeedInitializer)Activator.CreateInstance(x)).Seed(this);
            });
        }



        public override int SaveChanges()
        {
            if (_okToSave)
            {
                return 0;
            }
            _okToSave = false;
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            if (_okToSave)
            {
                return 0;
            }
            _okToSave = false;

            //CreatedByPrincipalId = "...",
            //CreatedOnUtc = DateTime.UtcNow,
            //DeletedByPrincipalId = null,
            //DeletedOnUtc = null,
            //LastModifiedByPrincipalId = "...",
            //LastModifiedOnUtc = DateTime.UtcNow,
            return base.SaveChanges(acceptAllChangesOnSuccess);
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


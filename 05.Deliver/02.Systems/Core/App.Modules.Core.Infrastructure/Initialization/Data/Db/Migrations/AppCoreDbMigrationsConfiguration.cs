//using App.Modules.Core.Infrastructure.Initialization.DependencyResolution;

//namespace App.Modules.Core.Infrastructure.Db.Migrations
//{
//    using App.Modules.Core.Infrastructure.Data;
//    using App.Modules.Core.Infrastructure.Db.Migrations.Seeding;
//    using App.Modules.Core.Infrastructure.Services;

//    /// <summary>
//    /// <para>
//    /// WARNING: 
//    /// You can change the name of any other class that is associated
//    /// to CodeFirst Migration, bar this one. Or its namespace. 
//    /// It is recorded in the Schema's Migration table. 
//    /// If changed, will block the creation of 'another' table with the same name 
//    /// as already exists -- until you either change the name back, or change the 
//    /// schema name.
//    /// </para>
//    /// <para>
//    /// Referenced by AppModuleDatabaseInitializer
//    /// </para>
//    /// </summary>
//    public sealed class AppCoreDbMigrationsConfiguration : DbMigrationsConfiguration<CoreModuleDbContext>
//    {
//        public AppCoreDbMigrationsConfiguration()
//        {
            
//            this.AutomaticMigrationsEnabled = false;
//            //Where to save Migrations (keep schemas distinct in their own folder):
//            this.MigrationsDirectory = @"Initialization\Db\Migrations\" + Constants.Module.Names.ModuleKey;
//        }

//        protected override void Seed(CoreModuleDbContext context)
//        {
//            // Hand off to a specialized class for Seeding.
//            AppDependencyLocator.Current.GetInstance< CoreModuleDbContextSeedingOrchestrator >().Initialize(context);
//        }
//    }
//}
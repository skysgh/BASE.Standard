using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Initialization;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Seeding.MutableData
{
    // Contract for Seeders that are invoked at the end of 
    // a Db CodeFirst Migration process.
    // Invoked 
    public interface IHasModuleSpecificDbContextMutableDataSeedingInitializer : IHasModuleSpecificInitializer
    {
        void SeedMutableData(ModuleDbContextBase context);
    }
}
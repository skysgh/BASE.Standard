using App.Modules.All.Infrastructure.Contracts;
using App.Modules.All.Infrastructure.Data.Db.Contexts;

namespace App.Modules.All.Infrastructure.Data.Db.Seeding.MutableData
{
    // Contract for Seeders that are invoked at the end of 
    // a Db CodeFirst Migration process.
    // Invoked 
    public interface IHasModuleSpecificDbContextMutableDataSeedingInitializer : IHasModuleSpecificInitializer
    {
        void SeedMutableData(ModuleDbContextBase context);
    }
}
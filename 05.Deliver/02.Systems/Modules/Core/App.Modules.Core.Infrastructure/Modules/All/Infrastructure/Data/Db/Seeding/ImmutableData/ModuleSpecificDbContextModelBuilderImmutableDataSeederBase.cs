using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData
{
    public abstract class ModuleSpecificDbContextModelBuilderImmutableDataSeederBase :
        IHasModuleSpecificDbContextModelBuilderImmutableDataSeedingInitializer
    {
        public abstract void DefineImmutableData(ModelBuilder modelBuilder);
    }
}
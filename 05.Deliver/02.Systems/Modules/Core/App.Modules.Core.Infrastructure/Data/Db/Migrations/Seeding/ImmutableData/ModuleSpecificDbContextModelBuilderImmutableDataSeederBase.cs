namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Seeding.ImmutableData
{
    using Microsoft.EntityFrameworkCore;

    public abstract class ModuleSpecificDbContextModelBuilderImmutableDataSeederBase :
        IHasModuleSpecificDbContextModelBuilderImmutableDataSeedingInitializer
    {
        public abstract void DefineImmutableData(ModelBuilder modelBuilder);
    }
}
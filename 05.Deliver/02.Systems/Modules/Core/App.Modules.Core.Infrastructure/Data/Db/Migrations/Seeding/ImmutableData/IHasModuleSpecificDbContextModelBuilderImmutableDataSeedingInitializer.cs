using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Seeding.ImmutableData
{
    public interface IHasModuleSpecificDbContextModelBuilderImmutableDataSeedingInitializer :
        IHasModuleSpecificInitializer
    {
        void DefineImmutableData(ModelBuilder modelBuilder);
    }

}
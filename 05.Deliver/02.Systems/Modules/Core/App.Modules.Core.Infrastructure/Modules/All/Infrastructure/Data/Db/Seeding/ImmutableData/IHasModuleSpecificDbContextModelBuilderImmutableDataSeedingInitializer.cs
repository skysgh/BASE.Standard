using App.Modules.All.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData
{
    public interface IHasModuleSpecificDbContextModelBuilderImmutableDataSeedingInitializer :
        IHasModuleSpecificInitializer
    {
        void DefineImmutableData(ModelBuilder modelBuilder);
    }

}
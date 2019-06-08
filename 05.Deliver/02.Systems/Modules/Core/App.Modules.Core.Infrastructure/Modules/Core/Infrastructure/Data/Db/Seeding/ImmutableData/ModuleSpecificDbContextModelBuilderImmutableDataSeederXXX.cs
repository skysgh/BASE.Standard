using App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Seeding.ImmutableData
{
    public class ModuleSpecificDbContextModelBuilderImmutableDataSeederXXX :
        ModuleSpecificDbContextModelBuilderImmutableDataSeederBase
    {
        public override void DefineImmutableData(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<XXX>().HasData(
            //    );
        }
    }
}
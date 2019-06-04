namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Seeding.ImmutableData
{
    using Microsoft.EntityFrameworkCore;

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
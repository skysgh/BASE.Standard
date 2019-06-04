using App.Modules.Core.Models.Entities;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Seeding.ImmutableData
{
    using Microsoft.EntityFrameworkCore;

    public class ModuleSpecificDbContextModelBuilderImmutableDataSeederTenant :
        ModuleSpecificDbContextModelBuilderImmutableDataSeederBase
    {
        public override void DefineImmutableData(ModelBuilder modelBuilder)
        {
            DefineDefaultTenant(modelBuilder);
        }

        private static void DefineDefaultTenant(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>().HasData(
                App.Modules.Core.Infrastructure.Constants.Tenancy.Default.DefaultTenant
                );
        }
        private static void DefineDefaultTenantProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenantProperty>().HasData(
                new TenantProperty { Id = 1.ToGuid(), TenantFK = Constants.Tenancy.Default.DefaultTenant.Id, Key = "Purpose", Value = "Default parent Tenancy." }
                );

        }
    }
}
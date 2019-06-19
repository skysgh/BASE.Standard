using App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Seeding.ImmutableData
{
    /// <summary>
    /// Class for
    ///  seeding of immutable data
    /// as part of 
    /// DbContext Migrations.
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData.ModuleSpecificDbContextModelBuilderImmutableDataSeederBase" />
    public class ModuleSpecificDbContextModelBuilderImmutableDataSeederTenant :
        ModuleSpecificDbContextModelBuilderImmutableDataSeederBase
    {
        /// <summary>
        /// Invoke to create immutable data
        /// as part of the current Migration.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
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
                new TenantProperty
                {
                    Id = 1.ToGuid(),
                    TenantFK = Constants.Tenancy.Default.DefaultTenant.Id,
                    Key = "Purpose",
                    Value = "Default parent Tenancy."
                }
                );

        }
    }
}
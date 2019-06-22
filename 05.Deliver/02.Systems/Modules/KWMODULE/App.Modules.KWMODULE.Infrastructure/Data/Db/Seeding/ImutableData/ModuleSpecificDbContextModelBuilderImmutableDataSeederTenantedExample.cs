using App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData;
using App.Modules.Core.Infrastructure.Constants.Demo;
using App.Modules.KWMODULE.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.KWMODULE.Infrastructure.Data.Db.Seeding.ImutableData
{
    /// <summary>
    ///     Implementation of a seeder that is invoked
    ///     as part of DbContext migration
    ///     to immutable reference data.
    /// </summary>
    /// <seealso
    ///     cref="App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData.ModuleSpecificDbContextModelBuilderImmutableDataSeederBase" />
    public class ModuleSpecificDbContextModelBuilderImmutableSeederTenantedExample :
        ModuleSpecificDbContextModelBuilderImmutableDataSeederBase
    {
        /// <summary>
        ///     Invoke to create immutable data
        ///     as part of the current Migration.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public override void DefineImmutableData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenantedExample>().HasData(
                //Policy and Privacy:
                new TenantedExample
                {
                    TenantFK = Tenancies.A.Id,
                    Title = "Some Title",
                    Description = "Some Description"
                },
                new TenantedExample
                {
                    TenantFK = Tenancies.A.Id,
                    Title = "Another Title"
                }
            );
        }
    }
}
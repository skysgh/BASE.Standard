using App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.KWMODULE.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.KWMODULE.Infrastructure.Data.Db.Seeding.ImmutableData
{
    /// <summary>
    /// Implementation of a seeder that is invoked
    /// as part of DbContext migration
    /// to immutable reference data.
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData.ModuleSpecificDbContextModelBuilderImmutableDataSeederBase" />
    public class ModuleSpecificDbContextModelBuilderImmutableSeederLinkedExample :
        ModuleSpecificDbContextModelBuilderImmutableDataSeederBase
    {
        /// <summary>
        /// Invoke to create immutable data
        /// as part of the current Migration.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public override void DefineImmutableData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinkedExample>().HasData(
            //Policy and Privacy:
            new LinkedExample
            {
                Title = "Some Title",
                Description = "Some Description",
                DataClassificationFK = NZDataClassification.Unspecified,
            },
            new LinkedExample
            {
                Title = "Another Title",
                DataClassificationFK = NZDataClassification.Confidential,
            }
        );

        }
    }
}

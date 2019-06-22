// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Seeding.ImmutableData
{
    /// <summary>
    ///     Class for
    ///     seeding of immutable data
    ///     as part of
    ///     DbContext Migrations.
    /// </summary>
    /// <seealso
    ///     cref="App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData.ModuleSpecificDbContextModelBuilderImmutableDataSeederBase" />
    public class ModuleSpecificDbContextModelBuilderImmutableSeederDataClassification :
        ModuleSpecificDbContextModelBuilderImmutableDataSeederBase
    {
        /// <summary>
        ///     Invoke to create immutable data
        ///     as part of the current Migration.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public override void DefineImmutableData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataClassification>().HasData(
                //Policy and Privacy:
                new DataClassification
                {
                    Id = NZDataClassification.Unspecified,
                    Title = "Unspecified",
                    DisplayOrderHint = 1
                },
                new DataClassification
                {
                    Id = NZDataClassification.Unclassified,
                    Title = "Unclassified",
                    DisplayOrderHint = 2
                },
                new DataClassification
                {
                    Id = NZDataClassification.InConfidence,
                    Title = "In Confidence",
                    DisplayOrderHint = 3
                },
                new DataClassification
                {
                    Id = NZDataClassification.Sensitive,
                    Title = "Sensitive",
                    DisplayOrderHint = 4
                },
                //National Security:
                new DataClassification
                {
                    Id = NZDataClassification.Restricted,
                    Title = "Restricted",
                    DisplayOrderHint = 5
                },
                new DataClassification
                {
                    Id = NZDataClassification.Confidential,
                    Title = "Confidential",
                    DisplayOrderHint = 6
                },
                new DataClassification
                {
                    Id = NZDataClassification.Secret,
                    Title = "Secret",
                    DisplayOrderHint = 7
                },
                new DataClassification
                {
                    Id = NZDataClassification.TopSecret,
                    Title = "TopSecret",
                    DisplayOrderHint = 8
                }
            );
        }
    }
}
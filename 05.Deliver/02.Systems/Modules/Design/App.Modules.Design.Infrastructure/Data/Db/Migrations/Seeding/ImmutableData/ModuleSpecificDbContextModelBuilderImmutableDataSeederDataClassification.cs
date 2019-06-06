using App.Modules.Core.Infrastructure.Data.Db.Migrations.Seeding.ImmutableData;
using App.Modules.Core.Models.Entities;
using App.Modules.Design.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Design.Infrastructure.Data.Db.Migrations.Seeding.ImmutableData
{
    public class ModuleSpecificDbContextModelBuilderImmutableSeederExample :
        ModuleSpecificDbContextModelBuilderImmutableDataSeederBase
    {
        public override void DefineImmutableData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Example>().HasData(
            //Policy and Privacy:
            new Example
            {
                DataClassificationFK = NZDataClassification.Unspecified,
            },
            new Example
            {
                DataClassificationFK = NZDataClassification.Confidential,
            }
                    );

        }
    }
}

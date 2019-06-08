using App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Design.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Design.Infrastructure.Data.Db.Seeding.ImmutableData
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

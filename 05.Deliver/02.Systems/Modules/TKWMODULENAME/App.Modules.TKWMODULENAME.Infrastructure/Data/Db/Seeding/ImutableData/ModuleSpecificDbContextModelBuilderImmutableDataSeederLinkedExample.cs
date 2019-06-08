using App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.TKWMODULENAME.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.TKWMODULENAME.Infrastructure.Data.Db.Seeding.ImmutableData
{
    public class ModuleSpecificDbContextModelBuilderImmutableSeederLinkedExample :
        ModuleSpecificDbContextModelBuilderImmutableDataSeederBase
    {
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

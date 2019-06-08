using App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.KWMODULE.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.KWMODULE.Infrastructure.Data.Db.Seeding.ImmutableData
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
                Title = "Some Title",
                Description = "Some Description"
            },
            new Example
            {
                Title = "Another Title"
            }
        );

        }
    }
}

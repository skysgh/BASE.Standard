using App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.TKWMODULENAME.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.TKWMODULENAME.Infrastructure.Data.Db.Seeding.ImmutableData
{
    public class ModuleSpecificDbContextModelBuilderImmutableSeederTenantedExample :
        ModuleSpecificDbContextModelBuilderImmutableDataSeederBase
    {
        public override void DefineImmutableData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenantedExample>().HasData(
            //Policy and Privacy:
            new TenantedExample
            {
                TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id, 
                Title = "Some Title",
                Description = "Some Description",
            },
            new TenantedExample
            {
                TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                Title = "Another Title",
            }
        );

        }
    }
}

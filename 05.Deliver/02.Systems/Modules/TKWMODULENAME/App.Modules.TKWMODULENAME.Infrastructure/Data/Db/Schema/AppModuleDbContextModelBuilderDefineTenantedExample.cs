using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.TKWMODULENAME.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.TKWMODULENAME.Infrastructure.Data.Db.Schema
{
    public class AppModuleDbContextModelBuilderDefineTenantedExample : ModuleSpecificDbContextModelBuilderDefineBase
    {
        public override void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<TenantedExample>(modelBuilder,
                    this.DefaultSchemaName
                );

            var order = 1;

            // Note the change from Untentanted... to TenantFK 
            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention()
                .Define<TenantedExample>(modelBuilder,
                ref order);

            modelBuilder.Entity<TenantedExample>()
                .Property(x => x.Title)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<TenantedExample>()
                .Property(x => x.Description)
                //.HasColumnOrder(order++)
                .IsRequired(false);

            

        }



    }
}
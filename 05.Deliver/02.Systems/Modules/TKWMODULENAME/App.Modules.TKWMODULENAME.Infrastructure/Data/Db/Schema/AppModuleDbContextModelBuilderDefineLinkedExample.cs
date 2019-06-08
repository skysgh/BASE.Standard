using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.TKWMODULENAME.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.TKWMODULENAME.Infrastructure.Data.Db.Schema
{
    public class AppModuleDbContextModelBuilderDefineLinkedExample : ModuleSpecificDbContextModelBuilderDefineBase
    {
        public override void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<LinkedExample>(modelBuilder,
                    this.DefaultSchemaName
                );

            var order = 1;

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention()
                .Define<Example>(modelBuilder,
                ref order);

            modelBuilder.Entity<LinkedExample>()
                .Property(x => x.Title)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<LinkedExample>()
                .Property(x => x.Description)
                //.HasColumnOrder(order++)
                .IsRequired(false);

            modelBuilder.Entity<LinkedExample>()
                .Property(x => x.DataClassificationFK)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<LinkedExample>()
                .HasOne(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);



        }



    }
}
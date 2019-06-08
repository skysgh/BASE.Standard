using App.Modules.All.Infrastructure.Constants.Db.Schemas;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.Design.Shared.Models.Entities.NonTenantSpecific;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Design.Infrastructure.Data.Db.Schema.Requirements
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineRequirement
        : ModuleSpecificDbContextModelBuilderDefineBase
    //: IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public override void DefineSchema(ModelBuilder modelBuilder)
        {

            new DefaultTableAndSchemaNamingConvention()
                .Define<Requirement>(
                    modelBuilder,
                    this.DefaultSchemaName
                    );

            var order = 1;


            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention()
                .Define<Requirement>(modelBuilder, ref order);

            modelBuilder.AssignIndex<Requirement>(x => x.ISO25010Quality, false);

            modelBuilder.Entity<Requirement>()
                .Property(x => x.ISO25010Quality)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<Requirement>()
                .Property(x => x.Title)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X2048)
                .IsRequired(true);

            modelBuilder.Entity<Requirement>()
                .Property(x => x.Description)
                //.HasColumnOrder(order++)
                //.IsMaxLength()
                .IsRequired(false);


        }

    }
}
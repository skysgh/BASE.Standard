using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models.Entities;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using App.Modules.Core.Infrastructure.Constants.Db;
    using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema;
    using App.Modules.Core.Infrastructure.Initialization;
    using Microsoft.EntityFrameworkCore;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineSystemRole : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<SystemRole>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                    );

            var order = 1;

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<SystemRole>(modelBuilder, ref order);

            // --------------------------------------------------
            // Indexes:

            modelBuilder.AssignIndex<SystemRole>(x => x.Key, false);

            // --------------------------------------------------
            // FK Properties:


            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<SystemRole>()
                .Property(x => x.Enabled)
                .IsRequired(true);

            modelBuilder.Entity<SystemRole>()
                .HasOne(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<SystemRole>()
                .Property(x => x.Key)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------

        }
    }
}
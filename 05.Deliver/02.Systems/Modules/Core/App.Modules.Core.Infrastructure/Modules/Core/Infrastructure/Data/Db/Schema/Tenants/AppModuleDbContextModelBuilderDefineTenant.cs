using App.Modules.All.Infrastructure.Constants.Db.Schemas;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.Tenants
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineTenant : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<Shared.Models.Entities.Tenant>(
                    modelBuilder,
                    Module.Id(this.GetType())
                );

            var order = 1;

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Shared.Models.Entities.Tenant>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:



            // --------------------------------------------------
            // Model Specific Properties:
            //modelBuilder.AssignIndex<Tenant>(x => x.IsDefault,true);
            modelBuilder.AssignIndex<Shared.Models.Entities.Tenant>(x => x.Key, false);
            //modelBuilder.AssignIndex<Tenant>(x => x.HostName, true);
            modelBuilder.AssignIndex<Shared.Models.Entities.Tenant>(x => x.DisplayName, false);


            modelBuilder.Entity<Shared.Models.Entities.Tenant>()
                .Property(x => x.IsDefault)
                //.HasColumnOrder(order++)
                .IsRequired(false);

            modelBuilder.Entity<Tenant>()
                .Property(x => x.Enabled)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<Shared.Models.Entities.Tenant>()
                .HasOne(x=>x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<Tenant>()
                .Property(x => x.Key)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);
            modelBuilder.Entity<Tenant>()
                .Property(x => x.HostName)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(false);

            modelBuilder.Entity<Tenant>()
                .Property(x => x.DisplayName)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);

            modelBuilder.Entity<Tenant>()
                .HasMany(x => x.Properties)
                .WithOne()
                .HasForeignKey(x => x.TenantFK);

            modelBuilder.Entity<Tenant>()
                .HasMany(x => x.Claims)
                .WithOne()
                .HasForeignKey(x => x.TenantFK);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}
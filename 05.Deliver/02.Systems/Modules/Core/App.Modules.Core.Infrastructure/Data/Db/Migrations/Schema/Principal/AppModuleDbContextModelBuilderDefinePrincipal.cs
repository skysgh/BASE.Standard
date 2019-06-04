using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Principal
{
    using System.ComponentModel.DataAnnotations.Schema;
    using App.Modules.Core.Infrastructure.Constants.Db;
    using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema;
    using App.Modules.Core.Infrastructure.Initialization;
    using Microsoft.EntityFrameworkCore;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefinePrincipal : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<Models.Entities.Principal>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );


            var order = 1;


            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Models.Entities.Principal>(modelBuilder, ref order);


            modelBuilder.Entity<Models.Entities.Principal>()
                .Property(x => x.Enabled)
                .IsRequired(true);

            modelBuilder.Entity<Models.Entities.Principal>()
                .HasOne(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<Models.Entities.Principal>()
                .Property(x => x.FullName)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X128)
                .IsRequired(false);

            modelBuilder.Entity<Models.Entities.Principal>()
                .Property(x => x.DisplayName)
                //.HasColumnOrder(order++)
                //.HasColumnAnnotation("Index",
                //    new IndexAnnotation(new IndexAttribute($"IX_{typeof(Principal).Name}_DisplayName") { IsUnique = false }))
                .HasMaxLength(TextFieldSizes.X128)
                .IsRequired(false);

            modelBuilder.Entity<Models.Entities.Principal>()
                .HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryFK);



            modelBuilder.Entity<Models.Entities.Principal>()
                .HasMany(x => x.Properties)
                .WithOne()
                .HasForeignKey(x => x.PrincipalFK);

            modelBuilder.Entity<Models.Entities.Principal>()
                .HasMany(x => x.Claims)
                .WithOne()
                .HasForeignKey(x => x.PrincipalFK);

            modelBuilder.Entity<Models.Entities.Principal>()
                .HasMany(x => x.Logins)
                .WithOne()
                .HasForeignKey(x => x.PrincipalFK);
        }
    }
}
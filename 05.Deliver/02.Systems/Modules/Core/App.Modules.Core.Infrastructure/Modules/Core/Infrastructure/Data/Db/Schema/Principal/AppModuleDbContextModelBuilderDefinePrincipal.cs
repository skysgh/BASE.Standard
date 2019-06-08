using App.Modules.All.Infrastructure.Constants.Db.Schemas;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.Principal
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefinePrincipal : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<Shared.Models.Entities.Principal>(
                    modelBuilder,
                    Module.Id(this.GetType())
                );


            var order = 1;


            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Shared.Models.Entities.Principal>(modelBuilder, ref order);


            modelBuilder.Entity<Shared.Models.Entities.Principal>()
                .Property(x => x.Enabled)
                .IsRequired(true);

            modelBuilder.Entity<Shared.Models.Entities.Principal>()
                .HasOne(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<Shared.Models.Entities.Principal>()
                .Property(x => x.FullName)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X128)
                .IsRequired(false);

            modelBuilder.Entity<Shared.Models.Entities.Principal>()
                .Property(x => x.DisplayName)
                //.HasColumnOrder(order++)
                //.HasColumnAnnotation("Index",
                //    new IndexAnnotation(new IndexAttribute($"IX_{typeof(Principal).Name}_DisplayName") { IsUnique = false }))
                .HasMaxLength(TextFieldSizes.X128)
                .IsRequired(false);

            modelBuilder.Entity<Shared.Models.Entities.Principal>()
                .HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryFK);



            modelBuilder.Entity<Shared.Models.Entities.Principal>()
                .HasMany(x => x.Properties)
                .WithOne()
                .HasForeignKey(x => x.PrincipalFK);

            modelBuilder.Entity<Shared.Models.Entities.Principal>()
                .HasMany(x => x.Claims)
                .WithOne()
                .HasForeignKey(x => x.PrincipalFK);

            modelBuilder.Entity<Shared.Models.Entities.Principal>()
                .HasMany(x => x.Logins)
                .WithOne()
                .HasForeignKey(x => x.PrincipalFK);
        }
    }
}
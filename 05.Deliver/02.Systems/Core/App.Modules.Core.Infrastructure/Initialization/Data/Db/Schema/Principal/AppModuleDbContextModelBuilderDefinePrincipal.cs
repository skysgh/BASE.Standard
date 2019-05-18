namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using App.Modules.Core.Infrastructure.Constants.Db;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefinePrincipal : IHasModuleSpecificDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<Principal>(modelBuilder);


            var order = 1;


            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Principal>(modelBuilder, ref order);


            modelBuilder.Entity<Principal>()
                .Property(x => x.Enabled)
                .IsRequired(true);

            modelBuilder.Entity<Principal>()
                .HasOne(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<Principal>()
                .Property(x => x.FullName)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X128)
                .IsRequired(false);

            modelBuilder.Entity<Principal>()
                .Property(x => x.DisplayName)
                //.HasColumnOrder(order++)
                //.HasColumnAnnotation("Index",
                //    new IndexAnnotation(new IndexAttribute($"IX_{typeof(Principal).Name}_DisplayName") { IsUnique = false }))
                .HasMaxLength(TextFieldSizes.X128)
                .IsRequired(false);

            modelBuilder.Entity<Principal>()
                .HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryFK);



            modelBuilder.Entity<Principal>()
                .HasMany(x => x.Properties)
                .WithOne()
                .HasForeignKey(x => x.PrincipalFK);

            modelBuilder.Entity<Principal>()
                .HasMany(x => x.Claims)
                .WithOne()
                .HasForeignKey(x => x.PrincipalFK);

            modelBuilder.Entity<Principal>()
                .HasMany(x => x.Logins)
                .WithOne()
                .HasForeignKey(x => x.PrincipalFK);
        }
    }
}
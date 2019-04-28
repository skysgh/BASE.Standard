namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;
    using App.Modules.Core.Infrastructure.Constants.Db;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Models.Entities.TenancySpecific;

    public class AppModuleDbContextModelBuilderDefinePrincipalProfileTag : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<PrincipalProfileTag>(modelBuilder);

            var order = 1;


            // --------------------------------------------------
            // Standard Properties:
            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<PrincipalProfileTag>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:



            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<PrincipalProfileTag>()
                .Property(x => x.Enabled)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<PrincipalProfileTag>()
                .Property(x => x.Title)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(PrincipalProfileTag).Name}_Text") { IsUnique = false }))
                .IsRequired(true);

            modelBuilder.Entity<PrincipalProfileTag>()
                .Property(x => x.DisplayOrderHint)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<PrincipalProfileTag>()
                .Property(x => x.DisplayStyleHint)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(false);

            // --------------------------------------------------
            // Entity Navigtation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}
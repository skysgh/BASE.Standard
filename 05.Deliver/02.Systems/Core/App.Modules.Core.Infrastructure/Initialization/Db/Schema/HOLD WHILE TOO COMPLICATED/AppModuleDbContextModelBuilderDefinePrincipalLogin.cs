namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using App.Modules.Core.Infrastructure.Constants.Db;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefinePrincipalLogin : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<PrincipalLogin>(modelBuilder);

            var order = 1;


            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<PrincipalLogin>(modelBuilder, ref order);

            modelBuilder.Entity<PrincipalLogin>()
                .Property(x => x.Enabled)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<PrincipalLogin>()
                .Property(x => x.IdPLogin)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(PrincipalLogin).Name}_IdpSubLogin") { IsUnique = true, Order = 1}))
                .IsRequired(true);

            modelBuilder.Entity<PrincipalLogin>()
                .Property(x => x.SubLogin)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(PrincipalLogin).Name}_IdpSubLogin") { IsUnique = true, Order = 2}))
                .IsRequired(true);

            modelBuilder.Entity<PrincipalLogin>()
                .Property(x => x.LastLoggedInUtc)
                //.HasColumnOrder(order++)
                .IsRequired(true);
        }
    }
}
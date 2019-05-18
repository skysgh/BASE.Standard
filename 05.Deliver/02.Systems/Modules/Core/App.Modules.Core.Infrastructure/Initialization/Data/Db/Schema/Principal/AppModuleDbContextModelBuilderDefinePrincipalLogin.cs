namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using App.Modules.Core.Infrastructure.Constants.Db;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefinePrincipalLogin : IHasModuleSpecificDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<PrincipalLogin>(modelBuilder);

            var order = 1;


            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<PrincipalLogin>(modelBuilder, ref order);


            modelBuilder.AssignIndex<PrincipalLogin>(x => new { x.IdPLogin, x.SubLogin}, true, "IdpLoginSubLogin");

            modelBuilder.Entity<PrincipalLogin>()
                .Property(x => x.Enabled)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<PrincipalLogin>()
                .Property(x => x.IdPLogin)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .IsRequired(true);

            modelBuilder.Entity<PrincipalLogin>()
                .Property(x => x.SubLogin)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsRequired(true);

            modelBuilder.Entity<PrincipalLogin>()
                .Property(x => x.LastLoggedInUtc)
                //.HasColumnOrder(order++)
                .IsRequired(true);
        }
    }
}
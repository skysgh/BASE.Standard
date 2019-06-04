using App.Modules.Core.Infrastructure.Constants.Db;
using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Principal
{
    public class AppModuleDbContextModelBuilderDefinePrincipalLogin : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<PrincipalLogin>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );

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
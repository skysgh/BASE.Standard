using App.Modules.All.Infrastructure.Constants.Db.Schemas;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.Principal
{
    public class AppModuleDbContextModelBuilderDefinePrincipalLogin : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<PrincipalLogin>(
                    modelBuilder,
                    Module.Id(this.GetType())
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
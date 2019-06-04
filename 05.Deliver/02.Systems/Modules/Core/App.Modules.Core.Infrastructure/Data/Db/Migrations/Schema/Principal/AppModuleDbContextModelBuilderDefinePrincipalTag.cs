using App.Modules.Core.Infrastructure.Constants.Db;
using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Principal
{
    public class AppModuleDbContextModelBuilderDefinePrincipalTag : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<PrincipalTag>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );

            var order = 1;


            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<PrincipalTag>(modelBuilder, ref order);

            modelBuilder.AssignIndex<PrincipalTag>(x => x.Title, false);


            modelBuilder.Entity<PrincipalTag>()
                .Property(x => x.Enabled)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<PrincipalTag>()
                .Property(x => x.Title)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);

            modelBuilder.Entity<PrincipalTag>()
                .Property(x => x.DisplayOrderHint)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<PrincipalTag>()
                .Property(x => x.DisplayStyleHint)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(false);
        }
    }
}
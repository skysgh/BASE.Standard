using App.Modules.Core.Infrastructure.Constants.Db;
using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Principal
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefinePrincipalProperty : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<PrincipalProperty>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );

            var order = 1;


            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<PrincipalProperty>(modelBuilder, ref order);

            modelBuilder.AssignIndex<PrincipalProperty>(x=>x.Key,false);

            modelBuilder.Entity<PrincipalProperty>()
                .Property(x => x.PrincipalFK)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<PrincipalProperty>()
                .Property(x => x.Key)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);

            modelBuilder.Entity<PrincipalProperty>()
                .Property(x => x.Value)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .IsRequired(false);
        }
    }
}
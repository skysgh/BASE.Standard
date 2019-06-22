// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Constants.Db.Schemas;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.Principal
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class
        AppModuleDbContextModelBuilderDefinePrincipalProperty : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<PrincipalProperty>(
                    modelBuilder,
                    Module.Id(GetType())
                );

            var order = 1;


            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<PrincipalProperty>(modelBuilder,
                ref order);

            modelBuilder.AssignIndex<PrincipalProperty>(x => x.Key);

            modelBuilder.Entity<PrincipalProperty>()
                .Property(x => x.PrincipalFK)
                //.HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<PrincipalProperty>()
                .Property(x => x.Key)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<PrincipalProperty>()
                .Property(x => x.Value)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .IsRequired(false);
        }
    }
}
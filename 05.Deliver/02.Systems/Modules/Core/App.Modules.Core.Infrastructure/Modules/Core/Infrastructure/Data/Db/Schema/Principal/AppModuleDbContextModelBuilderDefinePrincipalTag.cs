﻿using App.Modules.All.Infrastructure.Constants.Db.Schemas;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.Principal
{
    public class AppModuleDbContextModelBuilderDefinePrincipalTag : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<PrincipalTag>(
                    modelBuilder,
                    Module.Id(this.GetType())
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
﻿using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema;
using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Design.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Design.Infrastructure.Data.Db.Migrations.Schema.Notifications
{
    public class AppModuleDbContextModelBuilderDefineExample : ModuleSpecificDbContextModelBuilderDefineBase
    {
        public override void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<Example>(modelBuilder,
                    this.DefaultSchemaName
                );

            var order = 1;

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention()
                .Define<Example>(modelBuilder,
                ref order);

            modelBuilder.Entity<Example>()
                .Property(x => x.DataClassificationFK)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<Example>()
                .HasOne(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);



        }



    }
}
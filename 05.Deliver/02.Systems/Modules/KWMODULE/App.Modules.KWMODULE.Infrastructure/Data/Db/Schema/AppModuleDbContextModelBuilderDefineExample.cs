﻿using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.KWMODULE.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.KWMODULE.Infrastructure.Data.Db.Schema
{
    /// <summary>
    ///     Defines a single entity within
    ///     the given ModelBuilder of
    ///     a specif Logical Module DbContext.
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.Data.Db.Schema.ModuleSpecificDbContextModelBuilderDefineBase" />
    public class AppModuleDbContextModelBuilderDefineExample : ModuleSpecificDbContextModelBuilderDefineBase
    {
        /// <summary>
        ///     Defines the Module specific DbContext schema
        ///     for a given entity.
        ///     <para>
        ///         Invoked at startup.
        ///     </para>
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public override void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<Example>(modelBuilder,
                    DefaultSchemaName
                );

            var order = 1;

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention()
                .Define<Example>(modelBuilder,
                    ref order);

            modelBuilder.Entity<TenantedExample>()
                .Property(x => x.Title)
                //.HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<TenantedExample>()
                .Property(x => x.Description)
                //.HasColumnOrder(order++)
                .IsRequired(false);
        }
    }
}
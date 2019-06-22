// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Constants.Db.Schemas;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.Design.Shared.Models.Entities.NonTenantSpecific;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Design.Infrastructure.Data.Db.Schema.Requirements
{
    /// <summary>
    ///     A single DbContext Entity model map,
    ///     invoked via a Module's specific DbContext ModelBuilderOrchestrator
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.Data.Db.Schema.ModuleSpecificDbContextModelBuilderDefineBase" />
    public class AppModuleDbContextModelBuilderDefineRequirement
        : ModuleSpecificDbContextModelBuilderDefineBase
        //: IHasModuleSpecificDbContextModelBuilderSchemaInitializer
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
                .Define<Requirement>(
                    modelBuilder,
                    DefaultSchemaName
                );

            var order = 1;


            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention()
                .Define<Requirement>(modelBuilder, ref order);

            modelBuilder.AssignIndex<Requirement>(x => x.ISO25010Quality);

            modelBuilder.Entity<Requirement>()
                .Property(x => x.ISO25010Quality)
                //.HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<Requirement>()
                .Property(x => x.Title)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X2048)
                .IsRequired();

            modelBuilder.Entity<Requirement>()
                .Property(x => x.Description)
                //.HasColumnOrder(order++)
                //.IsMaxLength()
                .IsRequired(false);
        }
    }
}
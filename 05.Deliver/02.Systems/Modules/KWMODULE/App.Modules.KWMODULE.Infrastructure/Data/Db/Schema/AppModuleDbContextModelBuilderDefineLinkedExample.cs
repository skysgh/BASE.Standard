using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.KWMODULE.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.KWMODULE.Infrastructure.Data.Db.Schema
{
    /// <summary>
    /// Defines a single entity within
    /// the given ModelBuilder of
    /// a specif Logical Module DbContext.
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.Data.Db.Schema.ModuleSpecificDbContextModelBuilderDefineBase" />
    public class AppModuleDbContextModelBuilderDefineLinkedExample : ModuleSpecificDbContextModelBuilderDefineBase
    {
        /// <summary>
        /// Defines the Module specific DbContext schema
        /// for a given entity.
        /// <para>
        /// Invoked at startup.
        /// </para>
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public override void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<LinkedExample>(modelBuilder,
                    this.DefaultSchemaName
                );

            var order = 1;

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention()
                .Define<Example>(modelBuilder,
                ref order);

            modelBuilder.Entity<LinkedExample>()
                .Property(x => x.Title)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<LinkedExample>()
                .Property(x => x.Description)
                //.HasColumnOrder(order++)
                .IsRequired(false);

            modelBuilder.Entity<LinkedExample>()
                .Property(x => x.DataClassificationFK)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<LinkedExample>()
                .HasOne(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);



        }



    }
}
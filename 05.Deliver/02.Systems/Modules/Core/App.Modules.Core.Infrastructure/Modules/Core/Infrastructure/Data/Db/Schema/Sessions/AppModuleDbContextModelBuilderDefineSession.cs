using App.Modules.All.Infrastructure.Constants.Db.Schemas;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.Sessions
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineSession : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<Session>(
                    modelBuilder,
                    Module.Id(this.GetType())
                );

            var order = 1;


            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Session>(modelBuilder, ref order);

                // --------------------------------------------------
                // Indexes:
                modelBuilder.AssignIndex<Session>(x=>x.UniqueIdentifier,true);
            // --------------------------------------------------
            // FK Properties:

            modelBuilder.Entity<Session>()
                .HasOne(x => x.Principal)
                .WithMany()
                .HasForeignKey(x => x.PrincipalFK);

            modelBuilder.Entity<Session>()
                .HasMany(x => x.Operations)
                .WithOne()
                .HasForeignKey(x => x.SessionFK);

            modelBuilder.Entity<Session>()
                .Property(x => x.UniqueIdentifier)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<Session>()
                .Property(x => x.Enabled)
                //.HasColumnOrder(order++)
                .IsRequired(true);





            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}
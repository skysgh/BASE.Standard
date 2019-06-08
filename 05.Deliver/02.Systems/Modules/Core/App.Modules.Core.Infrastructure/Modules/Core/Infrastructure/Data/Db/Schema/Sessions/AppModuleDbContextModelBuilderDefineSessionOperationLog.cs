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
    public class AppModuleDbContextModelBuilderDefineSessionOperationLog : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<SessionOperation>(
                    modelBuilder,
                    Module.Id(this.GetType())
                );

            var order = 1;

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<SessionOperation>(modelBuilder, ref order);

                // --------------------------------------------------
                // Indexes:
                modelBuilder.AssignIndex<SessionOperation>(x=>x.ControllerName,false);

                modelBuilder.AssignIndex<SessionOperation>(x => x.ActionName, false);


            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.SessionFK)
                //.HasColumnOrder(order++)
                .IsRequired(false);

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.BeginDateTimeUtc)
                //.HasColumnOrder(order++)
                .IsRequired(true);
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.EndDateTimeUtc)
                //.HasColumnOrder(order++)
                .IsRequired(true);
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.Duration)
                //.HasColumnOrder(order++)
                .IsRequired(true);
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.ClientIp)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.Url)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X2048)
                .IsRequired(true);
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.ControllerName)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.ActionName)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.ActionArguments)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.ResponseCode)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);
            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}
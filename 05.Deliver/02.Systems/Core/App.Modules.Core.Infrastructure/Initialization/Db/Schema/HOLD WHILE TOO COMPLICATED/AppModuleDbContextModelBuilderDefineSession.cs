using System.ComponentModel.DataAnnotations.Schema;
using App.Modules.Core.Infrastructure.Constants.Db;

namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineSession : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<Session>(modelBuilder);

            var order = 1;


            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Session>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:

            modelBuilder.Entity<Session>()
                .HasRequired(x => x.Principal)
                .WithMany()
                .HasForeignKey(x => x.PrincipalFK);

            modelBuilder.Entity<Session>()
                .HasMany(x => x.Operations)
                .WithOptional()
                .HasForeignKey(x => x.SessionFK);

            modelBuilder.Entity<Session>()
                .Property(x => x.UniqueIdentifier)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(Session).Name}_UniqueIdentifier") { IsUnique = true }))
                .IsRequired(true);

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<Session>()
                .Property(x => x.Enabled)
                //.HasColumnOrder(order++)
                .IsRequired(true);





            // --------------------------------------------------
            // Entity Navigtation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}
using App.Modules.All.Infrastructure.Constants.Db.Schemas;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.Notifications
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineNotification : ModuleSpecificDbContextModelBuilderDefineBase
    {
        public override void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<Notification>(modelBuilder,
                    this.DefaultSchemaName
                );

            var order = 1;

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Notification>(modelBuilder, ref order);


            modelBuilder.AssignIndex<Notification>(x=>x.PrincipalFK, false);
            modelBuilder.AssignIndex<Notification>(x => x.From, false);


            modelBuilder.Entity<Notification>()
                .Property(x => x.Type)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<Notification>()
                .Property(x => x.Level)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<Notification>()
                .Ignore(x => x.IsRead);


            modelBuilder.Entity<Notification>()
                .Property(x => x.PrincipalFK)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<Notification>()
                .Property(x => x.DateTimeCreatedUtc)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<Notification>()
                .Property(x => x.DateTimeReadUtc)
                //.HasColumnOrder(order++)
                .IsRequired(false);




            modelBuilder.Entity<Notification>()
                .Property(x => x.From)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);

            modelBuilder.Entity<Notification>()
                .Property(x => x.Class)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);

            modelBuilder.Entity<Notification>()
                .Property(x => x.ImageUrl)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);


            modelBuilder.Entity<Notification>()
                .Property(x => x.Value)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<Notification>()
                .Property(x => x.Text)
                //.HasColumnOrder(order++)
                .IsFixedLength(false)
                .IsRequired(true);

        }

    }
}
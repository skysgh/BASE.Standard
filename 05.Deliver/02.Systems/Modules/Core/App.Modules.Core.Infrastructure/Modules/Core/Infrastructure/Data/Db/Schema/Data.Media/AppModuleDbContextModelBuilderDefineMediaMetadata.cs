using App.Modules.All.Infrastructure.Constants.Db.Schemas;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.Data.Media
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineMediaMetadata : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<MediaMetadata>(
                modelBuilder,
                Module.Id(this.GetType())
            );

            var order = 1;

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<MediaMetadata>(modelBuilder, ref order);

            modelBuilder.AssignIndex<MediaMetadata>(x=>x.ContentHash,false);
            modelBuilder.AssignIndex<MediaMetadata>(x => x.SourceFileName, false);
            modelBuilder.AssignIndex<MediaMetadata>(x => x.LocalName, true);



            modelBuilder.Entity<MediaMetadata>()
                .HasOne(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.UploadedDateTimeUtc)
                //.HasColumnOrder(order++)
                .IsRequired(true);
            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.ContentHash)
                .HasMaxLength(TextFieldSizes.X256)
                //.HasColumnOrder(order++)
                .IsRequired(true);
            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.ContentSize)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.MimeType)
                .HasMaxLength(TextFieldSizes.X256)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.SourceFileName)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsRequired(true);

            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.LatestScanDateTimeUtc)
                //.HasColumnOrder(order++)
                .IsRequired(false);

            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.LatestScanResults)
                //.HasColumnOrder(order++)
                .IsRequired(false);

            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.LatestScanMalwareDetetected)
                //.HasColumnOrder(order++)
                .IsRequired(false);

            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.LocalName)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsRequired(true);
        }
    }
}
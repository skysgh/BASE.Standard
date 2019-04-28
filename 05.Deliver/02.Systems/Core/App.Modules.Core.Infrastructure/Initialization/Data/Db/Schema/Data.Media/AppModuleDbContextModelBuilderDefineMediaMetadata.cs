namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using System;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Models.Entities.TenancySpecific;
    using Microsoft.EntityFrameworkCore;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineMediaMetadata : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<MediaMetadata>(modelBuilder);

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
                .HasMaxLength(Constants.Db.TextFieldSizes.X256)
                //.HasColumnOrder(order++)
                .IsRequired(true);
            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.ContentSize)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.MimeType)
                .HasMaxLength(Constants.Db.TextFieldSizes.X256)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.SourceFileName)
                //.HasColumnOrder(order++)
                .HasMaxLength(Constants.Db.TextFieldSizes.X256)
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
                .HasMaxLength(Constants.Db.TextFieldSizes.X256)
                .IsRequired(true);
        }
    }
}
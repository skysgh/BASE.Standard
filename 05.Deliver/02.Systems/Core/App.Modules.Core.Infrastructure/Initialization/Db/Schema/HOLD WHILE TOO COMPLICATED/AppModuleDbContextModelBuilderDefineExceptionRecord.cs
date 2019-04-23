namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Constants.Db;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineExceptionRecord : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<ExceptionRecord>(modelBuilder);

            var order = 1;

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<ExceptionRecord>(modelBuilder, ref order);

            modelBuilder.Entity<ExceptionRecord>()
                .Property(x => x.Level)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<ExceptionRecord>()
                .Property(x => x.Title)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X2048)
                .IsRequired(true);

            modelBuilder.Entity<ExceptionRecord>()
                .Property(x => x.Stack)
                //.HasColumnOrder(order++)
                .IsMaxLength()
                .IsRequired(true);


    }
}
}
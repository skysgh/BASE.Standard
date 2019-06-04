using System;
using App.Modules.Core.Infrastructure.Constants.Db;
using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.ExceptionRecord
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineExceptionRecord 
        : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<Models.Entities.ExceptionRecord>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );

            var order = 1;


            modelBuilder.DefineCustomId<Models.Entities.ExceptionRecord, Guid>(ref order);

            //modelBuilder.DefineTimeStamped<ExceptionRecord>(ref order);

            modelBuilder.Entity<Models.Entities.ExceptionRecord>()
                .Property(x => x.Level)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<Models.Entities.ExceptionRecord>()
                .Property(x => x.Message)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X2048)
                .IsRequired(true);

            modelBuilder.Entity<Models.Entities.ExceptionRecord>()
                .Property(x => x.Stack)
                //.HasColumnOrder(order++)
                //.IsMaxLength()
                .IsRequired(true);


    }
}
}
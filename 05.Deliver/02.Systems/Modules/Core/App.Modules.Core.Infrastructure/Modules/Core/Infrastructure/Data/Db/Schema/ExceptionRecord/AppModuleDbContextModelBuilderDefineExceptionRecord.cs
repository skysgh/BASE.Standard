// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Constants.Db.Schemas;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.ExceptionRecord
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineExceptionRecord
        : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<Shared.Models.Entities.ExceptionRecord>(
                    modelBuilder,
                    Module.Id(GetType())
                );

            var order = 1;


            modelBuilder.DefineCustomId<Shared.Models.Entities.ExceptionRecord, Guid>(ref order);

            //modelBuilder.DefineTimeStamped<ExceptionRecord>(ref order);

            modelBuilder.Entity<Shared.Models.Entities.ExceptionRecord>()
                .Property(x => x.Level)
                //.HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<Shared.Models.Entities.ExceptionRecord>()
                .Property(x => x.Message)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X2048)
                .IsRequired();

            modelBuilder.Entity<Shared.Models.Entities.ExceptionRecord>()
                .Property(x => x.Stack)
                //.HasColumnOrder(order++)
                //.IsMaxLength()
                .IsRequired();
        }
    }
}
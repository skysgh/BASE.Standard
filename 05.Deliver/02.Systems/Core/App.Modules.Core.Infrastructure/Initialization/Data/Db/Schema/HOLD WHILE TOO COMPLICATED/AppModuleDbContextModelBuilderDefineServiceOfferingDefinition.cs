namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using App.Modules.Core.Infrastructure.Contracts;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefineServiceOfferingDefinition : IHasAppModuleDbContextModelBuilderInitializer
    {


        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<ServiceOfferingDefinition>(modelBuilder);


            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<ServiceOfferingDefinition>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<ServiceOfferingDefinition>()
                .Property(x => x.ServiceFK)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            // --------------------------------------------------
            // Model Specific Properties:

            modelBuilder.DefineUniqueKey<ServiceOfferingDefinition>(ref order);

            modelBuilder.Entity<ServiceOfferingDefinition>()
                .Property(x => x.PrincipalLimit)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<ServiceOfferingDefinition>()
                .Property(x => x.ResourceLimit)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<ServiceOfferingDefinition>()
                .Property(x => x.DefaultCostPerMonth)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<ServiceOfferingDefinition>()
                .Property(x => x.DefaultCostPerYear)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            // --------------------------------------------------
            // FK Properties:

            modelBuilder.Entity<ServiceOfferingDefinition>()
                .HasRequired(x => x.Service)
                .WithMany()
                .HasForeignKey(x => x.ServiceFK);

            // --------------------------------------------------
            // Entity Navigation Properties:

            modelBuilder.Entity<ServiceOfferingDefinition>()
                .HasRequired(x => x.Service)
                .WithMany()
                .HasForeignKey(x => x.ServiceFK);
            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }


}


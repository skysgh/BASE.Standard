namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Constants.Db;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefineServicePlanDefinition : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new System.ArgumentNullException(nameof(modelBuilder));
            }

            new DefaultTableAndSchemaNamingConvention().Define<ServicePlanDefinition>(modelBuilder);


            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new UntenantedAuditedRecordStatedTimestampedGuidIdReferenceDataConvention().Define<ServicePlanDefinition>(modelBuilder, ref order);

            // Note that this Schema uses an Enum as the Id:

            // --------------------------------------------------
            // Model Specific Properties:

            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.DefineUniqueKey<ServicePlanDefinition>(ref order);

            modelBuilder.DefineDisplayableReferenceData<ServicePlanDefinition>(ref order);

            modelBuilder.Entity<ServicePlanDefinition>()
                .Property(x => x.PrincipalLimit)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<ServicePlanDefinition>()
                .Property(x => x.CostPerMonth)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<ServicePlanDefinition>()
                .Property(x => x.CostPerYear)
                //.HasColumnOrder(order++)
                .IsRequired(true);


            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            modelBuilder.Entity<ServicePlanDefinition>()
                .HasMany(p => p.ServiceAllocations)
                .WithMany()
                .Map(j =>
                {
                    j.ToTable(typeof(ServicePlanDefinition).Name + "__" + typeof(ServiceOfferingDefinition).Name);
                    j.MapLeftKey(typeof(ServicePlanDefinition).Name + "FK");
                    j.MapRightKey(typeof(ServiceOfferingDefinition).Name + "FK");
                });
            // --------------------------------------------------


        }
    }
}
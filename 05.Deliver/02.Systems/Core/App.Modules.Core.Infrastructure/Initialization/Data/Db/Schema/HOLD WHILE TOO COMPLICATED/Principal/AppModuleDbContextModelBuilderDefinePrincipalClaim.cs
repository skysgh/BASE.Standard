namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using App.Modules.Core.Infrastructure.Constants.Db;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefinePrincipalClaim : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<PrincipalClaim>(modelBuilder);

            var order = 1;


            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<PrincipalClaim>(modelBuilder, ref order);

            modelBuilder.AssignIndex<PrincipalClaim>(x=>x.Authority,false);

            modelBuilder.Entity<PrincipalClaim>()
                .Property(x => x.PrincipalFK)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<PrincipalClaim>()
                .Property(x => x.Authority)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);

            modelBuilder.DefineNonUniqueKey<PrincipalClaim>(ref order);
                

            modelBuilder.Entity<PrincipalClaim>()
                .Property(x => x.Value)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .IsRequired(false);
            modelBuilder.Entity<PrincipalClaim>()
                .Property(x => x.AuthoritySignature)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X2048)
                .IsRequired(true);
        }
    }
}
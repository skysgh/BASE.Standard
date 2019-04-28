using App.Modules.Core.Infrastructure.Migrations;

namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Models.Entities.TenancySpecific;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefineTenantMemberProfile2Tags : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {


            new DefaultTableAndSchemaNamingConvention().Define<TenantMemberProfile2TagAssignment>(modelBuilder);


            modelBuilder.Entity<TenantMemberProfile2TagAssignment>()
                .HasKey(x => new
                {
                    x.TenantFK,
                    x.TenantPrincipalFK,
                    x.TagFK
                });

            modelBuilder.Entity<TenantMemberProfile2TagAssignment>()
                .HasOne(x=>x.TenantPrincipal)
                .WithMany(x => x.TagAssignments)
                .HasForeignKey(x => x.TenantPrincipalFK);

            modelBuilder.Entity<TenantMemberProfile2TagAssignment>()
                .HasOne(x => x.Tag)
                .WithMany()
                .HasForeignKey(x => x.TagFK);
        }
    }
}
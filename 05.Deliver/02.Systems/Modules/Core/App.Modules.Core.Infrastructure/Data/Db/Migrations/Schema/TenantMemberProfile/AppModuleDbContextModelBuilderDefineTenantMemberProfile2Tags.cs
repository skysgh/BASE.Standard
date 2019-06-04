using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Models.Entities.TenantMember.Profile;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.TenantMemberProfile
{
    public class AppModuleDbContextModelBuilderDefineTenantMemberProfile2Tags : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {


            new DefaultTableAndSchemaNamingConvention()
                .Define<TenantMemberProfile2TagAssignment>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );


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
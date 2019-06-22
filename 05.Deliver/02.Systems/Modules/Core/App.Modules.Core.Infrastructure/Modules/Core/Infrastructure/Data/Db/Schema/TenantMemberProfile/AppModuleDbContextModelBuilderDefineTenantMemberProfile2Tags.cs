// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Shared.Models.Entities.TenantMember.Profile;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.TenantMemberProfile
{
    public class
        AppModuleDbContextModelBuilderDefineTenantMemberProfile2Tags :
            IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<TenantMemberProfile2TagAssignment>(
                    modelBuilder,
                    Module.Id(GetType())
                );


            modelBuilder.Entity<TenantMemberProfile2TagAssignment>()
                .HasKey(x => new
                {
                    x.TenantFK,
                    x.TenantPrincipalFK,
                    x.TagFK
                });

            modelBuilder.Entity<TenantMemberProfile2TagAssignment>()
                .HasOne(x => x.TenantPrincipal)
                .WithMany(x => x.TagAssignments)
                .HasForeignKey(x => x.TenantPrincipalFK);

            modelBuilder.Entity<TenantMemberProfile2TagAssignment>()
                .HasOne(x => x.Tag)
                .WithMany()
                .HasForeignKey(x => x.TagFK);
        }
    }
}
using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Principal
{
    public class AppModuleDbContextModelBuilderDefinePrincipal2Tags : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<PrincipalTagAssignment>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );


            modelBuilder.Entity<PrincipalTagAssignment>()
                .HasKey(x => new
                {
                    x.PrincipalFK,
                    x.TagFK
                });

            modelBuilder.Entity<PrincipalTagAssignment>()
                .HasOne(x => x.Principal)
                .WithMany(x => x.TagAssignment)
                .HasForeignKey(x => x.PrincipalFK);

            modelBuilder.Entity<PrincipalTagAssignment>()
                .HasOne(x => x.Tag)
                .WithMany() //Tags cannot be used to find what principals use it (would be too many).
                .HasForeignKey(x => x.TagFK);
        }
    }
}
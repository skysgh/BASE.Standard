namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefinePrincipal2Tags : IHasModuleSpecificDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<PrincipalTagAssignment>(modelBuilder);


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
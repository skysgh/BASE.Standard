namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Models.Entities.TenancySpecific;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefinePrincipalProfile2Tags : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<PrincipalProfile>(modelBuilder);

            modelBuilder.Entity<PrincipalProfile>()
                .HasMany(p => p.Tags)
                .WithMany()
                .Map(j =>
                {
                    j.ToTable(typeof(PrincipalProfile).Name + "2" + /*typeof(PrincipalProfileTag).Name*/ "Tag");
                    j.MapLeftKey(typeof(PrincipalProfile).Name + "FK");
                    j.MapRightKey(typeof(PrincipalProfileTag).Name + "FK");
                });
        }
    }
}
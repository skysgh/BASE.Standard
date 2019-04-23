namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefinePrincipal2Tags : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<Principal>(modelBuilder);

            modelBuilder.Entity<Principal>()
                .HasMany(p => p.Tags)
                .WithMany()
                .Map(j =>
                {
                    j.ToTable(typeof(Principal).Name + "2" + /*typeof(PrincipalTag).Name*/ "Tag");
                    j.MapLeftKey("PrincipalFK");
                    j.MapRightKey("TagFK");
                });
        }
    }
}
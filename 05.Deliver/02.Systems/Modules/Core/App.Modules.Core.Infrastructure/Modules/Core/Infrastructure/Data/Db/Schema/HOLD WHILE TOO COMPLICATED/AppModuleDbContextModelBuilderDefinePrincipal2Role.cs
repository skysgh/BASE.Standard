namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefinePrincipal2Role : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<Principal>(modelBuilder);

            //var order = 1;

            modelBuilder.Entity<Principal>()
                .HasMany(s => s.Roles)
                .WithMany()
                .Map(j =>
                {
                    j.ToTable(typeof(Principal).Name + "2" + /*(typeof(SystemRole)).Name)*/ "Role");
                    j.MapLeftKey("PrincipalFK");
                    j.MapRightKey("RoleFK");
                });
        }
    }
}
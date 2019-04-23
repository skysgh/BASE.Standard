namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using Microsoft.EntityFrameworkCore;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Shared.Models.Entities;

    public static class AppModuleModelBuilderCommonConfiguration
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Tenant>();
            modelBuilder.Ignore<TenantProperty>();
            modelBuilder.Ignore<TenantClaim>();

            modelBuilder.Ignore<Principal>();
            modelBuilder.Ignore<PrincipalProperty>();
            modelBuilder.Ignore<PrincipalClaim>();

            modelBuilder.Ignore<Session>();
            modelBuilder.Ignore<SessionOperation>();

            modelBuilder.Conventions.Add<IdConvention>();
        }
    }
}
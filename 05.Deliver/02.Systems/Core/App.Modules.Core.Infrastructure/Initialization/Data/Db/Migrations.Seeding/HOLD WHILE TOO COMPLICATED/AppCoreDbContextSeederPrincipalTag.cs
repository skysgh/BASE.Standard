namespace App.Modules.Core.Infrastructure.Db.Migrations.Seeding
{
    using App.Modules.Core.Infrastructure.Data;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Infrastructure.Services;

    public class CoreModuleDbContextSeederPrincipalTag : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederPrincipalTag(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(CoreModuleDbContext context)
        {

        }
    }
}
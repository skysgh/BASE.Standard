namespace App.Modules.Core.Infrastructure.Db.Migrations.Seeding
{
    using App.Modules.Core.Infrastructure.Data;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Infrastructure.Services;

    public class CoreModuleDbContextSeederPrincipalProperty : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederPrincipalProperty(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(CoreModuleDbContext context)
        {

        }
    }
}
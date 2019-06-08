using App.Modules.Core.Shared.Configuration.Settings;

namespace App.Modules.Core.Infrastructure.Services.Configuration.Implementations
{
    public class GeoIPServiceConfiguration : ICoreServiceConfigurationObject
    {
        public GeoIPServiceConfiguration(IAzureKeyVaultService keyVaultService)
        {
            Configuration = keyVaultService.GetObject<GeoIPServiceConfigurationSettings>();

        }

        public GeoIPServiceConfigurationSettings Configuration { get; }

    }
}

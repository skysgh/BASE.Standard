using App.Modules.Core.Configuration.Settings;

namespace App.Modules.Core.Infrastructure.Services.Configuration.Implementations.AzureConfiguration
{
    public class AzureDeploymentEnvironmentServiceConfiguration : ICoreServiceConfigurationObject
    {
        public AzureEnvironmentSettings Settings;

        public AzureDeploymentEnvironmentServiceConfiguration(IAzureKeyVaultService azureKeyVaultService)
        {
            Settings = azureKeyVaultService.GetObject<AzureEnvironmentSettings>();

        }
    }
}

using App.Modules.Core.Shared.Models.ConfigurationSettings;

namespace App.Modules.Core.Infrastructure.Services.Configuration.Implementations.AzureConfiguration
{
    public class AzureDeploymentEnvironmentServiceConfiguration
    {
        public AzureEnvironmentSettings Settings;

        public AzureDeploymentEnvironmentServiceConfiguration(IAzureKeyVaultService azureKeyVaultService)
        {
            Settings = azureKeyVaultService.GetObject<AzureEnvironmentSettings>();

        }
    }
}

// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Shared.Configuration.Settings;

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
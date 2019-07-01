// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{
    public class AzureDeploymentEnvironmentServiceConfiguration : ConfigurationObjectBase
    {
        public AzureEnvironmentSettings Settings;

        public AzureDeploymentEnvironmentServiceConfiguration(IAzureKeyVaultService azureKeyVaultService)
        {
            Settings = azureKeyVaultService.GetObject<AzureEnvironmentSettings>();
        }
    }
}
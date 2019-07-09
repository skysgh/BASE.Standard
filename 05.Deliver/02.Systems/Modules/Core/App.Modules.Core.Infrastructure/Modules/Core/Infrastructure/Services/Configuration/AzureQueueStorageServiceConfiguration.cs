// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{
    public class AzureQueueStorageServiceConfiguration : AzureServiceClientConfigurationObjectBase
    {
        public AzureQueueStorageServiceConfiguration(
            AzureEnvironmentSettings azureConfiguration,
            IConfigurationService configurationService
        )
        {
            configurationService.Get(this);

            if (string.IsNullOrEmpty(this.ResourceName))
            {
                this.ResourceName =
                    azureConfiguration.DefaultResourceName;
            }

        }

    }
}
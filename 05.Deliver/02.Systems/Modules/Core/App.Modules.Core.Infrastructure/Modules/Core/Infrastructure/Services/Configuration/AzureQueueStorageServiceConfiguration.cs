// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.Core.Infrastructure.Configuration.Settings;

namespace App.Modules.Core.Infrastructure.Services.Configuration
{
    public class AzureQueueStorageServiceConfiguration : AzureServiceClientConfigurationObjectBase
    {
        public AzureQueueStorageServiceConfiguration(
            AzureEnvironmentSettings defaultAzureConfiguration,
            IConfigurationService configurationService
        )
        {
            configurationService.Get(this);

            if (string.IsNullOrEmpty(ResourceName))
            {
                ResourceName =
                    defaultAzureConfiguration.DefaultResourceName;
            }

        }

    }
}
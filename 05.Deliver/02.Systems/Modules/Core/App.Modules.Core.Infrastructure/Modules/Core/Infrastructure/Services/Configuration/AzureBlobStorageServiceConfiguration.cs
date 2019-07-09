//Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{
    public class AzureBlobStorageServiceConfiguration
: AzureServiceClientConfigurationObjectBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureBlobStorageServiceConfiguration"/> class.
        /// </summary>
        public AzureBlobStorageServiceConfiguration(
            IConfigurationService configurationService,
            AzureEnvironmentSettings azureEnvironmentSettings)
        {

            configurationService.Get(this);

            if (string.IsNullOrEmpty(ResourceName))
            {
                ResourceName = azureEnvironmentSettings.DefaultResourceName;
            }


        }
    }
}


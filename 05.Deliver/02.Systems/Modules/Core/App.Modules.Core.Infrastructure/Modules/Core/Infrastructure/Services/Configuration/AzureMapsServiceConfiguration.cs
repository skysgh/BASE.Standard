// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services.Configuration
{

    public class AzureMapsServiceConfiguration
        : AzureServiceClientConfigurationObjectBase
    {


        public AzureMapsServiceConfiguration(
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

            if (BaseUri.IsNullOrEmpty())
            {
                BaseUri =
                    "https://atlas.microsoft.com"; // /search/address/reverse/json?subscription-key={subscription-key}&api-version=1.0&query={query}"
            }
        }
    }
}
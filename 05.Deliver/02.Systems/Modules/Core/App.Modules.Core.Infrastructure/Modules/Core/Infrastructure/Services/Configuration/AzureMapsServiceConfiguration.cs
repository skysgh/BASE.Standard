// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{

    public class AzureMapsServiceConfiguration
        : AzureServiceClientConfigurationObjectBase
    {


        public AzureMapsServiceConfiguration(
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

            if (this.BaseUri.IsNullOrEmpty())
            {
                this.BaseUri =
                    "https://atlas.microsoft.com"; // /search/address/reverse/json?subscription-key={subscription-key}&api-version=1.0&query={query}"
            }
        }
    }
}
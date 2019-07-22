// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services.Configuration
{
    public class AzureCognitiveServicesComputerVisionServiceConfiguration
        : AzureServiceClientConfigurationObjectBase
            , IHasAzureResourceName
    {
        public AzureCognitiveServicesComputerVisionServiceConfiguration(
            AzureEnvironmentSettings defaultAzureConfiguration,
            IConfigurationService configurationService)
        {

            configurationService.Get(this);

            if (string.IsNullOrEmpty(ResourceName))
            {
                ResourceName =
                    defaultAzureConfiguration.DefaultResourceName;
            }

            // https://australiaeast.api.cognitive.microsoft.com/vision/v1.0
        }


    }
}

// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{
    public class AzureCognitiveServicesComputerVisionServiceConfiguration
        : AzureServiceClientConfigurationObjectBase
            , IHasAzureResourceName
    {
        public AzureCognitiveServicesComputerVisionServiceConfiguration(
            AzureEnvironmentSettings azureConfiguration,
            IConfigurationService configurationService)
        {

            configurationService.Get(this);

            if (string.IsNullOrEmpty(this.ResourceName))
            {
                this.ResourceName =
                    azureConfiguration.DefaultResourceName;
            }

            // https://australiaeast.api.cognitive.microsoft.com/vision/v1.0
        }


    }
}

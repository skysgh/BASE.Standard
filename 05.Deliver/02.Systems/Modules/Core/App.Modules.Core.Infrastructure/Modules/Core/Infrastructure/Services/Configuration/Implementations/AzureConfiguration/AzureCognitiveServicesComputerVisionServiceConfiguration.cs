// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Shared.Configuration.Settings;

namespace App.Modules.Core.Infrastructure.Services.Configuration.Implementations.AzureConfiguration
{
    public class AzureCognitiveServicesComputerVisionServiceConfiguration : ICoreServiceConfigurationObject
    {
        public AzureCognitiveServicesComputerVisionServiceConfiguration(IAzureKeyVaultService keyVaultService)
        {
            var commonConfigurationSettings = keyVaultService.GetObject<AzureCommonConfigurationSettings>();

            var configuration = keyVaultService.GetObject<AzureCognitiveServicesComputerVisionConfigurationSettings>();

            if (string.IsNullOrEmpty(configuration.ResourceName))
            {
                configuration.ResourceName = commonConfigurationSettings.RootResourceName;
            }

            var authKey = configuration.Key;

            // https://australiaeast.api.cognitive.microsoft.com/vision/v1.0
        }
    }
}
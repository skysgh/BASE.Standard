// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{
    public class AzureCognitiveServicesComputerVisionServiceConfiguration
        : ConfigurationObjectBase
            , IHasServiceClientSecret
    {
        public AzureCognitiveServicesComputerVisionServiceConfiguration(
            AzureCommonConfigurationSettings azureCommonConfigurationSettings,
            IConfigurationService configurationService)
        {

            configurationService.Get(this);

            if (string.IsNullOrEmpty(this.ResourceName))
            {
                this.ResourceName =
                    azureCommonConfigurationSettings.RootResourceName;
            }

            // https://australiaeast.api.cognitive.microsoft.com/vision/v1.0
        }

        /// <summary>
        ///     Gets or sets (from AppSettings)
        ///     the ResourceName of this Computer Vision service.
        ///     <para>
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreIntegrationAzureCognitiveServicesComputerVisionDefaultResourceName)]

        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the client secret
        /// (ie, the secret key unique to
        /// the <see cref="!:ClientIdentifier" />.
        /// </summary>
        [ConfigurationSettingSource(SourceType.KeyVault)]
        [Alias(ConfigurationKeys
            .AppCoreIntegrationAzureCognitiveServicesComputerVisionDefaultAuthorizationKey)]
        public string ClientSecret { get; set; }

    }
}

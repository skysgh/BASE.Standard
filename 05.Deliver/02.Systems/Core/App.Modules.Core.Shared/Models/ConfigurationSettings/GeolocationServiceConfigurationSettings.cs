﻿using App.Modules.Core.Shared.Attributes;


namespace App.Modules.Core.Shared.Models.ConfigurationSettings
{
    public class GeoIPServiceConfigurationSettings
    {
        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationGeoIPServiceClientId)]
        public string ClientId
        {
            get; set;
        }

        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationGeoIPServiceClientSecret)]
        public string Secret
        {
            get; set;
        }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationGeoIPServiceBaseUri)]
        public string BaseUri
        {
            get; set;
        }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationGeoIPServiceClientMiscConfig)]
        public string MiscConfig
        {
            get; set;
        }
    }
}

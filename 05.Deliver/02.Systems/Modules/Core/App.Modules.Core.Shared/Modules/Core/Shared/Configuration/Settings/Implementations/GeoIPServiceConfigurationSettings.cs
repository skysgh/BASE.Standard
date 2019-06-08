using App.Modules.All.Shared.Attributes;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    public class GeoIPServiceConfigurationSettings
    {
        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationGeoIPServiceClientId)]
        public string ClientId
        {
            get; set;
        }

        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationGeoIPServiceClientSecret)]
        public string Secret
        {
            get; set;
        }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationGeoIPServiceBaseUri)]
        public string BaseUri
        {
            get; set;
        }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationGeoIPServiceClientMiscConfig)]
        public string MiscConfig
        {
            get; set;
        }
    }
}

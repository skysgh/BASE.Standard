

namespace App.Modules.Core.Configuration.Settings
{
    public class ScaniiHostConfiguration: IHostSettingsBasedConfigurationObject
    {

        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationMalwareDetectionClientId)]
        public string Key
        {
            get; set;
        }

        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationMalwareDetectionClientSecret)]
        public string Secret
        {
            get; set;
        }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationMalwareDetectionBaseUri)]
        public string BaseUri
        {
            get; set;
        }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationMalwareDetectionClientMiscConfig)]
        public string MiscConfig
        {
            get; set;
        }
    }
}
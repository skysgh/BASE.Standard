

namespace App.Modules.Core.Configuration.Settings
{
    public class Service01Configuration: IHostSettingsBasedConfigurationObject
    {

        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationService01ClientId)]
        public string Key
        {
            get; set;
        }

        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationService01ClientSecret)]
        public string Secret
        {
            get; set;
        }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationService01BaseUri)]
        public string BaseUri
        {
            get; set;
        }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationService01MiscConfig)]
        public string MiscConfig
        {
            get; set;
        }

    }
}
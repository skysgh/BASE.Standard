

namespace App.Modules.Core.Configuration.Settings
{
    public class SmtpServiceClientConfiguration: IHostSettingsBasedConfigurationObject
    {

        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationSmtpServiceClientId)]
        public string Key
        {
            get; set;
        }

        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationSmtpServiceClientSecret)]
        public string Secret
        {
            get; set;
        }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationSmtpServiceBaseUri)]
        public string BaseUri
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationSmtpServicePort)]
        public int? Port
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationSmtpServiceFrom)]
        public string From
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationSmtpServiceClientMiscConfig)]
        public string MiscConfig
        {
            get; set;
        }
    }
}
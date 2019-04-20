﻿

namespace App.Modules.Core.Shared.Models.Configuration.AppHost
{
    using App.Modules.Core.Shared.Attributes;
    using App.Modules.Core.Shared.Models.ConfigurationSettings;

    public class SmtpServiceClientConfiguration: IHostSettingsBasedConfigurationObject
    {

        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationSmtpServiceClientId)]
        public string Key
        {
            get; set;
        }

        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationSmtpServiceClientSecret)]
        public string Secret
        {
            get; set;
        }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationSmtpServiceBaseUri)]
        public string BaseUri
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationSmtpServicePort)]
        public int? Port
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationSmtpServiceFrom)]
        public string From
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationSmtpServiceClientMiscConfig)]
        public string MiscConfig
        {
            get; set;
        }
    }
}
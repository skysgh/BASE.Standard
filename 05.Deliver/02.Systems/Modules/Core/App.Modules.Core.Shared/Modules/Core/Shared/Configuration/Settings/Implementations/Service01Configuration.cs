// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Shared.Configuration.Settings
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Service01Configuration : IHostSettingsBasedConfigurationObject
    {
        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(SourceType.KeyVault)]
        [Alias(ConfigurationKeys.AppCoreIntegrationService01ClientId)]
        public string Key { get; set; }

        /// <summary>
        ///     Gets or sets the secret.
        ///     <para>
        ///         Make sure this kind of secrets are not gotten from AppSettings.
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.KeyVault)]
        [Alias(ConfigurationKeys.AppCoreIntegrationService01ClientSecret)]
        public string Secret { get; set; }


        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationService01BaseUri)]
        public string BaseUri { get; set; }


        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationService01MiscConfig)]
        public string MiscConfig { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
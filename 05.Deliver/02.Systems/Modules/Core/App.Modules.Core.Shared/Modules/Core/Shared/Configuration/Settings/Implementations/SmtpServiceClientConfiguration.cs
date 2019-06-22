// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    /// <summary>
    ///     TODO
    /// </summary>
    /// <seealso cref="App.Modules.Core.Shared.Configuration.Settings.IHostSettingsBasedConfigurationObject" />
    public class SmtpServiceClientConfiguration
        : IHostSettingsBasedConfigurationObject,
            IHasKey, IHasSecret

    {
        /// <summary>
        ///     Gets or sets the base URI
        ///     of the remote service.
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationSmtpServiceBaseUri)]
        public string BaseUri { get; set; }

        /// <summary>
        ///     Gets or sets the port.
        /// </summary>
        /// <value>
        ///     The port.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationSmtpServicePort)]
        public int? Port { get; set; }

        /// <summary>
        ///     Gets or sets System Identity's From value used to connect.
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationSmtpServiceFrom)]
        public string From { get; set; }

        /// <summary>
        ///     Gets or sets misc configuration.
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationSmtpServiceClientMiscConfig)]
        public string MiscConfig { get; set; }

        /// <summary>
        ///     Make sure this kind of secrets are not gotten from AppSettings.
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationSmtpServiceClientId)]
        public string Key { get; set; }

        /// <summary>
        ///     Gets or sets the secret.
        ///     <para>
        ///         Make sure this kind of secrets are not gotten from AppSettings.
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.KeyVault)]
        [Alias(ConfigurationKeys.AppCoreIntegrationSmtpServiceClientSecret)]
        public string Secret { get; set; }
    }
}
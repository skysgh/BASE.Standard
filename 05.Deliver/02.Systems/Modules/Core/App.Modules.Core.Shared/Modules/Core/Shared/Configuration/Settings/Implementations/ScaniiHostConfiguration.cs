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
    public class ScaniiHostConfiguration
        : IHostSettingsBasedConfigurationObject,
            IHasKey,
            IHasSecret
    {
        /// <summary>
        ///     TODO: Gets or sets the base URI.
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationMalwareDetectionBaseUri)]
        public string BaseUri { get; set; }


        /// <summary>
        ///     Gets or sets any misc configuration.
        /// </summary>
        /// <value>
        ///     The misc configuration.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationMalwareDetectionClientMiscConfig)]
        public string MiscConfig { get; set; }

        // Make sure this kind of secrets are not gotten from AppSettings.
        /// <summary>
        ///     Gets or sets the unique key of the object,
        ///     by which it is indexed when persisted
        ///     (in additional to any primary Id).
        ///     <para>
        ///         Not the same as <see cref="T:App.Modules.All.Shared.Models.IHasName" />
        ///     </para>
        ///     .
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationMalwareDetectionClientId)]
        public string Key { get; set; }

        // Make sure this kind of secrets are not gotten from AppSettings.
        /// <summary>
        ///     Gets or sets the secret.
        /// </summary>
        [ConfigurationSettingSource(SourceType.KeyVault)]
        [Alias(ConfigurationKeys.AppCoreIntegrationMalwareDetectionClientSecret)]
        public string Secret { get; set; }
    }
}
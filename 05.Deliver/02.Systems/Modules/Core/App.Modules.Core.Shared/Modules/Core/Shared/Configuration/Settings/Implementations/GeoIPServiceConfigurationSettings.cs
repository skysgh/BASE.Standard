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
    public class GeoIPServiceConfigurationSettings : IHasSecret
    {
        /// <summary>
        ///     Gets or sets the client identifier.
        ///     <para>
        ///         Make sure this kind of secrets are not gotten from AppSettings.
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationGeoIPServiceClientId)]
        public string ClientId { get; set; }


        /// <summary>
        ///     Gets or sets the base URI.
        /// </summary>
        /// <value>
        ///     The base URI.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationGeoIPServiceBaseUri)]
        public string BaseUri { get; set; }


        /// <summary>
        ///     Gets or sets any misc configuration.
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationGeoIPServiceClientMiscConfig)]
        public string MiscConfig { get; set; }

        // Make sure this kind of secrets are not gotten from AppSettings.
        /// <summary>
        ///     Gets or sets the secret.
        /// </summary>
        [ConfigurationSettingSource(SourceType.KeyVault)]
        [Alias(ConfigurationKeys.AppCoreIntegrationGeoIPServiceClientSecret)]
        public string Secret { get; set; }
    }
}
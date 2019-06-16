using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    /// <summary>
    /// TODO
    /// </summary>
    public class GeoIPServiceConfigurationSettings: IHasSecret
    {
        /// <summary>
        /// Gets or sets the client identifier.
        /// <para>
        /// Make sure this kind of secrets are not gotten from AppSettings.
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationGeoIPServiceClientId)]
        public string ClientId
        {
            get; set;
        }

        // Make sure this kind of secrets are not gotten from AppSettings.
        /// <summary>
        /// Gets or sets the secret.
        /// </summary>
        [ConfigurationSettingSource(SourceType.KeyVault)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationGeoIPServiceClientSecret)]
        public string Secret
        {
            get; set;
        }


        /// <summary>
        /// Gets or sets the base URI.
        /// </summary>
        /// <value>
        /// The base URI.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationGeoIPServiceBaseUri)]
        public string BaseUri
        {
            get; set;
        }


        /// <summary>
        /// Gets or sets any misc configuration.
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationGeoIPServiceClientMiscConfig)]
        public string MiscConfig
        {
            get; set;
        }
    }
}

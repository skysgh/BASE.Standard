// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{
    public class GeoLocationServiceConfiguration 
        : ConfigurationObjectBase
            , IHasServiceClientInformation
    {
        public GeoLocationServiceConfiguration(
            IConfigurationService configurationService)
        {
            configurationService.Get(this);
        }


        /// <summary>
        ///     Gets or sets the base URI.
        /// </summary>
        /// <value>
        ///     The base URI.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationGeoLocationServiceBaseUri)]
        public string BaseUri { get; set; }


        /// <summary>
        ///     Gets or sets any misc configuration.
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationGeoLocationServiceClientMiscConfig)]
        public string MiscConfig { get; set; }

        /// <summary>
        ///     Gets or sets the client identifier.
        ///     <para>
        ///         Make sure this kind of secrets are not gotten from AppSettings.
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationGeoLocationServiceClientId)]
        public string ClientIdentifier { get; set; }


        // Make sure this kind of secrets are not gotten from AppSettings.
        /// <summary>
        ///     Gets or sets the secret.
        /// </summary>
        [ConfigurationSettingSource(SourceType.KeyVault)]
        [Alias(ConfigurationKeys.AppCoreIntegrationGeoLocationServiceClientSecret)]
        public string ClientSecret { get; set; }
    }
}
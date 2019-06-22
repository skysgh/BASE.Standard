// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    /// <summary>
    ///     AppHost/KeyVault sourced settings required to configure
    ///     the DocumentDbService.
    /// </summary>
    /// <seealso cref="IHostSettingsBasedConfigurationObject" />
    public class AzureDocumentDbConfigurationSettings : IHostSettingsBasedConfigurationObject,
        IKeyVaultBasedConfigurationObject
    {
        /// <summary>
        ///     Gets or sets the root name for Azure resource names.
        ///     <para>
        ///         If not provided in AppSettings, using
        ///         <see cref="ConfigurationKeys.AppCoreIntegrationAzureDocumentDbResourceName" />
        ///         falls back to
        ///         <see cref="ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName" />
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreIntegrationAzureDocumentDbResourceName)]
        public string ResourceName { get; set; }


        //[Alias(Constants.ConfigurationKeys.AppCoreIntegrationAzureDocumentDbEndpointUrl)]
        //public string EndpointUrl { get; set; }

        /// <summary>
        ///     Gets or sets the authorization key.
        ///     <para>
        ///         Note: should not be needed if we are using MSI
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.KeyVault)]
        [Alias(ConfigurationKeys.AppCoreIntegrationAzureDocumentDbAuthorizationKey)]
        public string AuthorizationKey { get; set; }
    }
}
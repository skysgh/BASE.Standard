// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    /// <summary>
    ///     An immutable host configuration object
    ///     describing the settings to access the
    ///     Azure Key Vault Service.
    /// </summary>
    public class AzureKeyVaultConfigurationSettings : IHostSettingsBasedConfigurationObject
    {
        /// <summary>
        ///     Gets or sets the name of the System's KeyVault.
        ///     <para>
        ///         If not provided in AppSettings, using
        ///         <see cref="ConfigurationKeys.AppCoreIntegrationAzureKeyVaultStoreResourceName" />
        ///         falls back to
        ///         <see cref="ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName" />
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreIntegrationAzureKeyVaultStoreResourceName)]
        public string ResourceName { get; set; }


        //[ConfigurationSettingSource(SourceType.AppSetting)]
        //[Alias(Constants.ConfigurationKeys.AppCoreIntegrationAzureKeyVaultStoreSystemKeyPrefix)]
        //public string KeyPrefix
        //{
        //    get; set;
        //}
    }
}
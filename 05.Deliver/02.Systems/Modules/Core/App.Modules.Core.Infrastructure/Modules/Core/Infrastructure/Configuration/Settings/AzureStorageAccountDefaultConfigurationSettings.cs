// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Infrastructure.Configuration.Settings
{
    /// <summary>
    ///     An immutable host configuration object
    ///     describing the configuration needed to
    ///     access the
    ///     Media Azure Storage Account Service.
    /// </summary>
    public class AzureStorageAccountDefaultConfigurationSettings
        : ConfigurationObjectBase,
        IStorageAccountConfigurationSettings
        , IHasServiceClientSecret
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AzureStorageAccountDefaultConfigurationSettings" /> class.
        /// </summary>
        public AzureStorageAccountDefaultConfigurationSettings()
        {
            ResourceNameSuffix = "";
        }


        /// <summary>
        ///     Gets or sets the default name of the resource.
        /// </summary>
        /// <value>
        ///     The default name of the resource.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName)]
        public string DefaultResourceName { get; set; }

        /// <summary>
        ///     Gets or sets (from AppSettings)
        ///     the ResourceName of this StorageAccount.
        ///     <para>
        ///         <para>
        ///             If not provided in AppSettings, using
        ///             <see cref="ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDefaultResourceName" />
        ///             falls back to
        ///             <see cref="ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName" />
        ///             plus 'di'.
        ///         </para>
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDefaultResourceName)]
        public string ResourceName { get; set; }


        /// <summary>
        ///     Gets or sets (from AppSettings)
        ///     the ResourceName Suffix of this StorageAccount.
        ///     <para>
        ///         <para>
        ///             Default Value is 'm1'.
        ///         </para>
        ///         <para>
        ///             The value is appended to <see cref="ResourceName" />.
        ///         </para>
        ///         <para>
        ///             Can be overridden (or cleared) using
        ///             <see cref="ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDefaultResourceNameSuffix" />,
        ///             in AppSettings.
        ///         </para>
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDefaultResourceNameSuffix)]
        public string ResourceNameSuffix { get; set; }


        /// <summary>
        ///     Gets or sets
        ///     (from the KeyVault)
        ///     the Key for the ServiceAccount.
        /// </summary>
        /// <value>
        ///     The key.
        /// </value>
        [ConfigurationSettingSource(SourceType.KeyVault)]
        [Alias(ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDefaultKey)]
        public string ClientSecret { get; set; }
    }
}
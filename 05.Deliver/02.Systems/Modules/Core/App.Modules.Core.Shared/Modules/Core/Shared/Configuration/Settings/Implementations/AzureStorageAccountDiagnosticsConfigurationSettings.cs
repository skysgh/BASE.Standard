using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    /// <summary>
    /// An immutable host configuration object 
    /// describing the configuration needed to 
    /// access the
    /// Diagnostics Azure Storage Account Service.
    /// </summary>
    public class AzureStorageAccountDiagnosticsConfigurationSettings: IKeyVaultBasedConfigurationObject, IStorageAccountConfigurationSettings
    {
        /// <summary>
        /// Gets or sets (from AppSettings)
        /// the ResourceName of this StorageAccount.
        /// <para>
        /// <para>
        /// If not provided in AppSettings, using
        /// <see cref="ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDiagnosticsResourceName"/>
        /// falls back to 
        /// <see cref="ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName"/>
        /// plus 'di'.
        /// </para>
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDiagnosticsResourceName)]
        public string ResourceName
        {
            get; set;
        }


        /// <summary>
        /// Gets or sets (from AppSettings)
        /// the ResourceName Suffix of this StorageAccount.
        /// <para>
        /// <para>
        /// Default Value is 'di'.
        /// </para>
        /// <para>
        /// The value is appended to <see cref="ResourceName"/>.
        /// </para>
        /// <para>
        /// Can be overridden (or cleared) using 
        /// <see cref="ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDiagnosticsResourceNameSuffix"/>,
        /// in AppSettings.
        /// </para>
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDiagnosticsResourceNameSuffix)]
        public string ResourceNameSuffix
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets 
        /// (from the KeyVault) 
        /// the Key for the ServiceAccount.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        [ConfigurationSettingSource(SourceType.KeyVault)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDiagnosticsKey)]
        public string Key
        {
            get; set;
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="AzureStorageAccountDefaultConfigurationSettings"/> class.
        /// </summary>
        public AzureStorageAccountDiagnosticsConfigurationSettings()
        {
            ResourceNameSuffix = "di";
        }

    }
}

using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Configuration.Settings
{

    public class AzureRedisCacheConfigurationSettings
    {

        /// <summary>
        /// Gets or sets (from AppSettings)
        /// the ResourceName of this StorageAccount.
        /// <para>
        /// <para>
        /// If not provided in AppSettings, using
        /// <see cref="ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDefaultResourceName"/>
        /// falls back to 
        /// <see cref="ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName"/>
        /// plus 'di'.
        /// </para>
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureRedisCacheResourceName)]
        public string ResourceName
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureRedisCacheDefaultAuthorizationKey)]
        public string Key
        {
            get;set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureRedisEnabled)]
        public string Enabled
        {
            get; set;
        }
    }
}

namespace App.Modules.Core.Configuration.Settings
{
    public class AzureCognitiveServicesComputerVisionConfigurationSettings
    {
        /// <summary>
        /// Gets or sets (from AppSettings)
        /// the ResourceName of this Computer Vision service.
        /// <para>
        /// <para>
        /// If not provided in AppSettings, using
        /// <see cref="ConfigurationKeys.AppCoreIntegrationAzureComputerVisionDefaultResourceName"/>
        /// falls back to 
        /// <see cref="Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName"/>
        /// plus 'di'.
        /// </para>
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureCognitiveServicesComputerVisionDefaultResourceName)]
        public string ResourceName
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureCognitiveServicesComputerVisionDefaultAuthorizationKey)]
        public string Key
        {
            get; set;
        }

    }
}

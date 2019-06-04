namespace App.Modules.Core.Configuration.Settings
{
    /// <summary>
    /// An immutable host configuration object 
    /// describing the configuration of the 
    /// Application Insights service.
    /// </summary>
    public class ApplicationInsightsConfigurationSettings: IKeyVaultBasedConfigurationObject
    {

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureApplicationInsightsInstrumentationKey)]
        public string Key { get; set; }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureApplicationInsightsInstrumentationKeyEnabled)]
        public bool Enabled { get; set; }
    }
}

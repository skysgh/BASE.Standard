namespace App.Modules.Core.Configuration.Settings
{
    public class DemoConfigurationSettings : IHostSettingsBasedConfigurationObject
    {
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreDemoMode)]
        public bool DemoMode
        {
            get; set;
        }
    }
}

using App.Modules.All.Shared.Attributes;

namespace App.Modules.Core.Shared.Configuration.Settings
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

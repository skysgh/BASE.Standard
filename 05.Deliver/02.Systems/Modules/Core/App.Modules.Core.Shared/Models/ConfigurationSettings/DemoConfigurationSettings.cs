﻿namespace App.Modules.Core.Shared.Models.ConfigurationSettings
{
    using App.Modules.Core.Shared.Attributes;

    public class DemoConfigurationSettings : IHostSettingsBasedConfigurationObject
    {
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreDemoMode)]
        public bool DemoMode
        {
            get; set;
        }
    }
}

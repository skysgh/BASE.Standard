using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <seealso cref="App.Modules.Core.Shared.Configuration.Settings.IHostSettingsBasedConfigurationObject" />
    public class DemoConfigurationSettings : IHostSettingsBasedConfigurationObject
    {
        /// <summary>
        /// Gets or sets a value indicating whether [demo mode].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [demo mode]; otherwise, <c>false</c>.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreDemoMode)]
        public bool DemoMode
        {
            get; set;
        }
    }
}

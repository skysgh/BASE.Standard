using App.Modules.All.Shared.Attributes;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    public class MediaManagementConfigurationSettings: IHostSettingsBasedConfigurationObject
    {
        private string _hashType;

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreMediaHashType)]
        public string HashType
        {
            get { return this._hashType?? "SHA-256"; }
            set { this._hashType = value; }
        }
    }
}
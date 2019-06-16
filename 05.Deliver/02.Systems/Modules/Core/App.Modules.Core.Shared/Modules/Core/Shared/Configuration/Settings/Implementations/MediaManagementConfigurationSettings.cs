using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <seealso cref="App.Modules.Core.Shared.Configuration.Settings.IHostSettingsBasedConfigurationObject" />
    public class MediaManagementConfigurationSettings: IHostSettingsBasedConfigurationObject
    {
        private string _hashType;

        /// <summary>
        /// Gets or sets the type of the hash.
        /// </summary>
        /// <value>
        /// The type of the hash.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreMediaHashType)]
        public string HashType
        {
            get { return this._hashType?? "SHA-256"; }
            set { this._hashType = value; }
        }
    }
}
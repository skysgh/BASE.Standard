// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    /// <summary>
    ///     TODO
    /// </summary>
    /// <seealso cref="App.Modules.Core.Shared.Configuration.Settings.IHostSettingsBasedConfigurationObject" />
    public class MediaManagementConfigurationSettings : IHostSettingsBasedConfigurationObject
    {
        private string _hashType;

        /// <summary>
        ///     Gets or sets the type of the hash.
        /// </summary>
        /// <value>
        ///     The type of the hash.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreMediaHashType)]
        public string HashType
        {
            get => _hashType ?? "SHA-256";
            set => _hashType = value;
        }
    }
}
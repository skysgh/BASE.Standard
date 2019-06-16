using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    /// <summary>
    /// TODO
    /// </summary>
    public class AzureCognitiveServicesComputerVisionConfigurationSettings
        : IHostSettingsBasedConfigurationObject,
            IHasKey
    {
        /// <summary>
        /// Gets or sets (from AppSettings)
        /// the ResourceName of this Computer Vision service.
        /// <para>
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureCognitiveServicesComputerVisionDefaultResourceName)]
        public string ResourceName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the unique key of the object,
        /// by which it is indexed when persisted
        /// (in additional to any primary Id).
        /// <para>
        /// Not the same as <see cref="T:App.Modules.All.Shared.Models.IHasName" /></para>.
        /// </summary>
        [ConfigurationSettingSource(SourceType.KeyVault)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureCognitiveServicesComputerVisionDefaultAuthorizationKey)]
        public string Key
        {
            get; set;
        }

    }
}

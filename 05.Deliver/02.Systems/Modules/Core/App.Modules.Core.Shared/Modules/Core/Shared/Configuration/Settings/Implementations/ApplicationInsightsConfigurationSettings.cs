using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    /// <summary>
    /// An immutable host configuration object 
    /// describing the configuration of the 
    /// Application Insights service.
    /// </summary>
    public class ApplicationInsightsConfigurationSettings: 
        IKeyVaultBasedConfigurationObject, IHasKey, IHasEnabled
    {

        /// <summary>
        /// Gets or sets the unique key of the object,
        /// by which it is indexed when persisted
        /// (in additional to any primary Id).
        /// <para>
        /// Not the same as <see cref="T:App.Modules.All.Shared.Models.IHasName" /></para>.
        /// </summary>
        [ConfigurationSettingSource(SourceType.KeyVault)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureApplicationInsightsInstrumentationKey)]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:App.Modules.All.Shared.Models.IHasEnabled" /> is enabled.
        /// <para>
        /// See <see cref="T:App.Modules.All.Shared.Models.IHasEnabledBeginningUtcDateTime" />
        /// and <see cref="T:App.Modules.All.Shared.Models.IHasEnabledEndUtcDateTime" /></para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureApplicationInsightsInstrumentationKeyEnabled)]
        public bool Enabled { get; set; }
    }
}

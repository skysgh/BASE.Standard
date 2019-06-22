// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    /// <summary>
    ///     Azure subscription configuration information.
    /// </summary>
    /// <seealso cref="App.Modules.Core.Shared.Configuration.Settings.IHostSettingsBasedConfigurationObject" />
    /// <seealso cref="App.Modules.Core.Shared.Configuration.Settings.IKeyVaultBasedConfigurationObject" />
    public class AzureEnvironmentSettings
        : IHostSettingsBasedConfigurationObject
            , IKeyVaultBasedConfigurationObject
    {
        /// <summary>
        ///     Gets or sets the subscription identifier
        ///     <para>
        ///         There should always be more than one,
        ///         as Production Data environments
        ///         should always be separate from
        ///         all other Non-Production Data.
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreEnvironmentSubscriptionId)]
        public string SubscriptionId { get; set; }

        /// <summary>
        ///     Gets or sets the AAD tenant identifier.
        /// </summary>
        /// <value>
        ///     The tenant identifier.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreEnvironmentTenantId)]
        public string TenantId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the resource group.
        ///     this system is deployed to.
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreEnvironmentResourceGroupName)]
        public string ResourceGroupName { get; set; }

        /// <summary>
        ///     Gets or sets the resource group location.
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreEnvironmentResourceGroupLocation)]
        public string ResourceGroupLocation { get; set; }
    }
}
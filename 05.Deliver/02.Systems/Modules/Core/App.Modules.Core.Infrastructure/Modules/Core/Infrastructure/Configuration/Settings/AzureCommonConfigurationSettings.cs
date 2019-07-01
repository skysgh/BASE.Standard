// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Infrastructure.Configuration.Settings
{
    /// <summary>
    ///  Configure in host settings:
    /// <![CDATA[
    /// "AzureCommonConfigurationSettings": {
    /// }
    /// ]]>
    /// </summary>
    /// <seealso cref="IConfigurationObject" />
    public class AzureCommonConfigurationSettings
        : ConfigurationObjectBase
    {
        /// <summary>
        ///     Gets or sets the root of the Azure Resource Names
        ///     (eg: something like 'corpappbranchenv')
        ///     from AppSettings,
        ///     using the
        ///     <see cref="ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName" />
        ///     AppSettings
        ///     key.
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName)]
        public string RootResourceName { get; set; }
    }
}
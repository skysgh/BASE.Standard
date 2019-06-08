using App.Modules.All.Shared.Attributes;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    public class AzureCommonConfigurationSettings: IHostSettingsBasedConfigurationObject
    {
        /// <summary>
        /// Gets or sets the root of the Azure Resource Names
        /// (eg: something like 'corpappbranchenv')
        /// from AppSettings, 
        /// using the 
        /// <see cref="ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName"/>
        /// AppSettings 
        /// key.
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName)]
        public string RootResourceName
        {
            get; set;
        }
    }
}
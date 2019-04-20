﻿namespace App.Modules.Core.Shared.Models.ConfigurationSettings
{
    using App.Modules.Core.Shared.Attributes;

    public class AzureCommonConfigurationSettings: IHostSettingsBasedConfigurationObject
    {
        /// <summary>
        /// Gets or sets the root of the Azure Resource Names
        /// (eg: something like 'corpappbranchenv')
        /// from AppSettings, 
        /// using the 
        /// <see cref="Constants.ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName"/>
        /// AppSettings 
        /// key.
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName)]
        public string RootResourceName
        {
            get; set;
        }
    }
}
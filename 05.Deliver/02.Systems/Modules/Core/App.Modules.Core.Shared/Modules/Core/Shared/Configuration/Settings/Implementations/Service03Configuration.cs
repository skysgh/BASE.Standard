// Copyright MachineBrains, Inc. 2019

// namespace App.Modules.Core.Shared.Models.Configuration.AppHost
// {
//     using App.Modules.Core.Shared.Attributes;
//     using App.Modules.Core.Shared.Models.ConfigurationSettings;

//     public class Service03Configuration: IHostSettingsBasedConfigurationObject
//     {

//         // Make sure this kind of secrets are not gotten from AppSettings.
//         [ConfigurationSettingSource(SourceType.KeyVault)]
//         [Alias(Constants.ConfigurationKeys.AppCoreIntegrationService03ClientId)]
//         public string Key
//         {
//             get; set;
//         }

//         // Make sure this kind of secrets are not gotten from AppSettings.
//         [ConfigurationSettingSource(SourceType.KeyVault)]
//         [Alias(Constants.ConfigurationKeys.AppCoreIntegrationService03ClientSecret)]
//         public string Secret
//         {
//             get; set;
//         }


//         [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
//         [Alias(Constants.ConfigurationKeys.AppCoreIntegrationService03BaseUri)]
//         public string BaseUri
//         {
//             get; set;
//         }


//         [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
//         [Alias(Constants.ConfigurationKeys.AppCoreIntegrationService03MiscConfig)]
//         public string MiscConfig
//         {
//             get; set;
//         }

//     }
// }


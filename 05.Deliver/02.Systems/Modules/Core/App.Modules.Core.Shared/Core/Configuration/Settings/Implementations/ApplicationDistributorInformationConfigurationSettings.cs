using System;
using App.Modules.Core.Models;

namespace App.Modules.Core.Configuration.Settings
{
    /// <summary>
    /// An immutable host configuration object 
    /// describing the Distributor of the application
    /// (distinct from the Creator) in many commercial cases.
    /// </summary>
    /// <seealso cref="IHasName" />
    /// <seealso cref="IHasDescription" />
    public class ApplicationDistributorInformationConfigurationSettings : IHostSettingsBasedConfigurationObject, IHasName , IHasDescription
    {
        public ApplicationDistributorInformationConfigurationSettings()
        {
            this.Id = new Guid();
        }

        // OData always needs an Id. It can be another field, but too much bother
        // to configure it...
        public Guid Id { get; set; }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias( Core.Shared.Constants.ConfigurationKeys.AppCoreApplicationProviderName)]
        public string Name
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreApplicationProviderDescription)]
        public string Description
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreApplicationProviderSiteUrl)]
        public string SiteUrl { get; set; }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreApplicationProviderContactUrl)]
        public string ContactUrl { get; set; }
    }
}
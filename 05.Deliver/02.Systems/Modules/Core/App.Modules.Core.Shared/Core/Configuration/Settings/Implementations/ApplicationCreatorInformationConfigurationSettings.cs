using System;
using App.Modules.Core.Models;

namespace App.Modules.Core.Configuration.Settings
{
    /// <summary>
    /// An immutable host configuration object 
    /// describing the Creator of the application
    /// (distinct from the Distributor/Resellers) in many commercial cases.
    /// <para>
    /// An Immutable Host Settings configuration object
    /// retrieved from the Host Settings.
    /// </para>
    /// </summary>
    /// <seealso cref="IHasName" />
    /// <seealso cref="IHasDescription" />
    public class ApplicationCreatorInformationConfigurationSettings : IHostSettingsBasedConfigurationObject,  IHasName, IHasDescription
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationCreatorInformationConfigurationSettings"/> class.
        /// </summary>
        public ApplicationCreatorInformationConfigurationSettings()
        {
            this.Id = new Guid();
        }

        // OData always needs an Id. It can be another field, but too much bother
        // to configure it...
        public Guid Id
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreApplicationCreatorName)]
        public string Name
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreApplicationCreatorDescription)]
        public string Description
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreApplicationCreatorSiteUrl)]
        public string SiteUrl
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreApplicationCreatorContactUrl)]
        public string ContactUrl
        {
            get; set;
        }
    }
}
using System;
using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    /// <summary>
    /// An immutable host configuration object 
    /// describing the Distributor of the application
    /// (distinct from the Creator) in many commercial cases.
    /// </summary>
    /// <seealso cref="IHasName" />
    /// <seealso cref="IHasDescription" />
    public class ApplicationDistributorInformationConfigurationSettings 
        : IHostSettingsBasedConfigurationObject
            , IHasGuidId
            , IHasName 
            , IHasDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDistributorInformationConfigurationSettings"/> class.
        /// </summary>
        public ApplicationDistributorInformationConfigurationSettings()
        {
            this.Id = new Guid();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// <para>
        /// OData always needs an Id. It can be another field, but too much bother
        /// to configure it...
        /// </para>
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        /// Gets or sets the unique Name
        /// of the object
        /// <para>
        /// See difference with <see cref="T:App.Modules.All.Shared.Models.IHasKey" />.
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias( Core.Shared.Constants.ConfigurationKeys.AppCoreApplicationProviderName)]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the optional displayed description.
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreApplicationProviderDescription)]
        public string Description
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the site URL.
        /// </summary>
        /// <value>
        /// The site URL.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreApplicationProviderSiteUrl)]
        public string SiteUrl { get; set; }


        /// <summary>
        /// Gets or sets the contact URL.
        /// </summary>
        /// <value>
        /// The contact URL.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreApplicationProviderContactUrl)]
        public string ContactUrl { get; set; }
    }
}
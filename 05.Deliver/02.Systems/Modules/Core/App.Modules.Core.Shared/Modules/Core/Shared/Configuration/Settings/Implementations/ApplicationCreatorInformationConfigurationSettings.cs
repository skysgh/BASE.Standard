// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    /// <summary>
    ///     An immutable host configuration object
    ///     describing the Creator of the application
    ///     (distinct from the Distributor/Resellers) in many commercial cases.
    ///     <para>
    ///         An Immutable Host Settings configuration object
    ///         retrieved from the Host Settings.
    ///     </para>
    /// </summary>
    /// <seealso cref="IHasName" />
    /// <seealso cref="IHasDescription" />
    public class ApplicationCreatorInformationConfigurationSettings : IHostSettingsBasedConfigurationObject, IHasName,
        IHasDescription
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationCreatorInformationConfigurationSettings" /> class.
        /// </summary>
        public ApplicationCreatorInformationConfigurationSettings()
        {
            Id = new Guid();
        }

        // OData always needs an Id. It can be another field, but too much bother
        // to configure it...
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the site URL.
        /// </summary>
        /// <value>
        ///     The site URL.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreApplicationCreatorSiteUrl)]
        public string SiteUrl { get; set; }

        /// <summary>
        ///     Gets or sets the contact URL.
        /// </summary>
        /// <value>
        ///     The contact URL.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreApplicationCreatorContactUrl)]
        public string ContactUrl { get; set; }

        /// <summary>
        ///     Gets or sets the optional displayed description.
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreApplicationCreatorDescription)]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the unique Name
        ///     of the object
        ///     <para>
        ///         See difference with <see cref="T:App.Modules.All.Shared.Models.IHasKey" />.
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreApplicationCreatorName)]
        public string Name { get; set; }
    }
}
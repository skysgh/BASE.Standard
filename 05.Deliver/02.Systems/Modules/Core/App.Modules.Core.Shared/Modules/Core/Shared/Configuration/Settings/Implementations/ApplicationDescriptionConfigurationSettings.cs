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
    ///     describing the Application (ie, shows up on the header).
    /// </summary>
    public class ApplicationDescriptionConfigurationSettings
        : IHostSettingsBasedConfigurationObject, IHasName, IHasDescription
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationDescriptionConfigurationSettings" /> class.
        /// </summary>
        public ApplicationDescriptionConfigurationSettings()
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
        ///     Gets or sets the description/byline of the Application.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreApplicationDescription)]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the name of the Application
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreApplicationName)]
        public string Name { get; set; }
    }
}
// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Attributes.Enums;

namespace App.Modules.All.Shared.Attributes
{
    /// <summary>
    ///     Attribute to decorate
    ///     Configuration objects (which implement
    ///     either <c>IHostSettingsBasedConfigurationObject</c>
    ///     or <c>IKeyVaultBasedConfigurationObject</c>
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public class ConfigurationSettingSource : Attribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigurationSettingSource" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public ConfigurationSettingSource(SourceType source)
        {
            Source = source;
        }

        /// <summary>
        ///     Gets where to look for the Value.
        /// </summary>
        /// <value>
        ///     The source.
        /// </value>
        public SourceType Source { get; }
    }
}
// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{
    /// <summary>
    ///     An immutable host configuration object
    ///     describing the configuration of the
    ///     Application Insights service.
    /// </summary>
    public class ApplicationInsightsConfiguration
        : ConfigurationObjectBase,
            IHasServiceClientIdentifier,
            IHasEnabled
    {

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ApplicationInsightsConfiguration"/>
        /// class.
        /// </summary>
        public ApplicationInsightsConfiguration(IConfigurationService configurationService)
        {
            configurationService.Get(this);

        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="T:App.Modules.All.Shared.Models.IHasEnabled" /> is enabled.
        ///     <para>
        ///         See <see cref="T:App.Modules.All.Shared.Models.IHasEnabledBeginningUtcDateTime" />
        ///         and <see cref="T:App.Modules.All.Shared.Models.IHasEnabledEndUtcDateTime" />
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreIntegrationAzureApplicationInsightsInstrumentationKeyEnabled)]
        public bool Enabled { get; set; }



        /// <summary>
        /// Gets or sets the service's client account identifier.
        /// <para>
        /// In other words, the Azure Insights 'Key'.
        /// </para>
        /// </summary>
        public string ClientIdentifier
        {
            get;set;
        }
    }
}
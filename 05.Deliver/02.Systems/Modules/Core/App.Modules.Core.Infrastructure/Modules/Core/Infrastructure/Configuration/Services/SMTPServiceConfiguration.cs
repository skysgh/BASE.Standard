﻿// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.All.Shared.DependencyResolution.Lifecycles;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{
    /// <summary>
    ///     Configuration object to be injected into the
    ///     implementation of <see cref="ISmtpService" />
    ///     <para>
    ///         Inherits from <see cref="IConfigurationObject" />
    ///         which inherits from <see cref="IHasSingletonLifecycle" />
    ///         to hint at startup that the Configuration object should be
    ///         IoC registered for the duration of the application (not the thread).
    ///         as some configuration hits remote services (eg: Azure KeyVault)
    ///         which would be rather slow.
    ///     </para>
    /// </summary>
    /// <seealso cref="IConfigurationObject" />
    public class SMTPServiceConfiguration : ConfigurationObjectBase
        ,IHasServiceClientInformation
    {
        public SMTPServiceConfiguration(IConfigurationService configurationService)
        {
            configurationService.Get(this);
        }


        /// <summary>
        ///     Gets or sets the base URI
        ///     of the remote service.
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationSmtpServiceBaseUri)]
        public string BaseUri { get; set; }

        /// <summary>
        ///     Gets or sets the port.
        /// </summary>
        /// <value>
        ///     The port.
        /// </value>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationSmtpServicePort)]
        public int? Port { get; set; }

        /// <summary>
        ///     Gets or sets System Identity's From value used to connect.
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationSmtpServiceFrom)]
        public string From { get; set; }

        /// <summary>
        ///     Gets or sets misc configuration.
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationSmtpServiceClientMiscConfig)]
        public string MiscConfig { get; set; }

        [ConfigurationSettingSource(SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(ConfigurationKeys.AppCoreIntegrationSmtpServiceClientId)]
        public string ClientIdentifier { get; set; }

        /// <summary>
        ///     Gets or sets the secret.
        ///     <para>
        ///         Make sure this kind of secrets are not gotten from AppSettings.
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.KeyVault)]
        [Alias(ConfigurationKeys.AppCoreIntegrationSmtpServiceClientSecret)]
        public string ClientSecret { get; set; }

    }
}
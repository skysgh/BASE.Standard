// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{
    /// <summary>
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
    public class AzureDocumentDbServiceConfiguration
        : ConfigurationObjectBase
            , IHasAzureResourceName
            , IHasServiceClientSecret
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DocumentDbServiceConfiguration" /> class.
        /// </summary>
        public AzureDocumentDbServiceConfiguration(
            AzureEnvironmentSettings azureConfiguration,
            IConfigurationService configurationService)
        {

            if (string.IsNullOrEmpty(this.ResourceName))
            {
                this.ResourceName = azureConfiguration.DefaultResourceName;
            }


            TimeoutMilliseconds = 10 * 1000;
        }

        public Uri EndpointUrl { get; set; }


        public int TimeoutMilliseconds { get; set; }



        /// <summary>
        ///     Gets or sets the root name for Azure resource names.
        ///     <para>
        ///         If not provided in AppSettings, using
        ///         <see cref="ConfigurationKeys.AppCoreIntegrationAzureDocumentDbResourceName" />
        ///         falls back to
        ///         <see cref="ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName" />
        ///     </para>
        /// </summary>
        public string ResourceName { get; set; }


        //[Alias(Constants.ConfigurationKeys.AppCoreIntegrationAzureDocumentDbEndpointUrl)]
        //public string EndpointUrl { get; set; }

        /// <summary>
        ///     Gets or sets the authorization key.
        ///     <para>
        ///         Note: should not be needed if we are using MSI
        ///     </para>
        /// </summary>
        public string ClientSecret { get; set; }

    }
}
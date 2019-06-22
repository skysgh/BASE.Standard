// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.Core.Shared.Configuration.Settings;

namespace App.Modules.Core.Infrastructure.Services.Configuration.Implementations
{
    /// <summary>
    ///     <para>
    ///         Inherits from <see cref="ICoreServiceConfigurationObject" />
    ///         whic inherits from <see cref="IHasSingletonLifecycle" />
    ///         to hint at startup that the Configuration object should be
    ///         IoC registered for the duration of the application (not the thread).
    ///         as some configuration hits remote services (eg: Azure KeyVault)
    ///         which would be rather slow.
    ///     </para>
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.Configuration.ICoreServiceConfigurationObject" />
    public class AzureDocumentDbServiceConfiguration : ICoreServiceConfigurationObject
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DocumentDbServiceConfiguration" /> class.
        /// </summary>
        public AzureDocumentDbServiceConfiguration(IAzureKeyVaultService keyVaultService)
        {
            var commonConfigurationSettings = keyVaultService.GetObject<AzureCommonConfigurationSettings>();
            var configuration = keyVaultService.GetObject<AzureDocumentDbConfigurationSettings>();
            if (string.IsNullOrEmpty(configuration.ResourceName))
            {
                configuration.ResourceName = commonConfigurationSettings.RootResourceName;
            }

            //this.EndpointUrl = configuration.EndpointUrl;
            AuthorizationKey = configuration.AuthorizationKey;

            TimeoutMilliseconds = 10 * 1000;
        }

        public Uri EndpointUrl { get; set; }

        public string AuthorizationKey { get; set; }

        public int TimeoutMilliseconds { get; set; }
    }
}
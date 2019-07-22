// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.DependencyResolution.Lifecycles;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services.Configuration
{
    /// <summary>
    /// Inherits from <see cref="IConfigurationObject" />
    /// which inherits from <see cref="IHasSingletonLifecycle" />
    /// to hint at startup that the Configuration object should be
    /// IoC registered for the duration of the application (not the thread).
    /// as some configuration hits remote services (eg: Azure KeyVault)
    /// which would be rather slow.
    /// </summary>
    /// <seealso cref="AzureServiceClientConfigurationObjectBase" />
    /// <seealso cref="IHasAzureResourceName" />
    /// <seealso cref="IHasServiceClientSecret" />
    /// <seealso cref="IConfigurationObject" />
    public class AzureDocumentDbServiceConfiguration
        : AzureServiceClientConfigurationObjectBase
            , IHasAzureResourceName
            , IHasServiceClientSecret
    {
        /// <summary>
        ///     Initializes a new instance of the
        /// <see cref="AzureDocumentDbServiceConfiguration" /> class.
        /// </summary>
        public AzureDocumentDbServiceConfiguration(
            AzureEnvironmentSettings defaultAzureConfiguration,
            IConfigurationService configurationService)
        {

            if (string.IsNullOrEmpty(ResourceName))
            {
                ResourceName = defaultAzureConfiguration.DefaultResourceName;
            }


            Timeout = 10;
        }



    }
}
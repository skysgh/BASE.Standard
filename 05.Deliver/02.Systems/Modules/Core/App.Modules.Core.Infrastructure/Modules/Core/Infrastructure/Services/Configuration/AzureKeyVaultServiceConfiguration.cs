// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.DependencyResolution.Lifecycles;
using App.Modules.Core.Infrastructure.Configuration.Settings;

namespace App.Modules.Core.Infrastructure.Services.Configuration
{
    /// <summary>
    ///     Configuration object to be injected into the
    ///     implementation of <see cref="IAzureKeyVaultService" />
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
    public class AzureKeyVaultServiceConfiguration
        : AzureServiceClientConfigurationObjectBase
    {
        //public readonly AadApplicationRegistrationInformationHostConfiguration AADClientInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureKeyVaultServiceConfiguration"/> class.
        /// <para>
        /// Constructor only used from within
        /// Program, when checking whether to use
        /// KeyVault for configuration (as it slows
        /// startup considerably).
        /// </para>
        /// </summary>
        public AzureKeyVaultServiceConfiguration()
        {

        }


        /// <summary>
        ///     Initializes a new instance of the <see cref="AzureKeyVaultServiceConfiguration" /> class.
        ///     <para>
        ///         Note that this one of the only settings that goes directly to HostSettingsService.
        ///     </para>
        /// </summary>
        /// <param name="hostSettingsService">The host settings service.</param>
        public AzureKeyVaultServiceConfiguration(
            AzureEnvironmentSettings defaultAzureConfiguration,
            IConfigurationService configurationService)
        {
            KeyStandardNameComponentDivider = "-";
            KeyIllegalCharacters = new[] { ":", "." };

            configurationService.Get(this);

            //Get the resourceName for the KeyVault

            if (string.IsNullOrEmpty(ResourceName))
            {
                // Get the configuration for this service:
                ResourceName =
                    defaultAzureConfiguration.DefaultResourceName;
            }

            if (BaseUri.IsNullOrEmpty())
            {
                BaseUri =
                    $"https://{ResourceName}.vault.azure.net";
            }

            //this.KeyPrefix = configuration.KeyPrefix;


            // To make the Service Client, you should be using MSI...but in case you are not...
            // But - really - you really shouldn't be putting this kind of secrets in either AppSettings either 
            // by code (where it could inadvertently get checked in) or by vsts build pipelines
            // where everyone/contractors can see them..and reuse from remote locations.
            //this.AADClientInfo = hostSettingsService.GetObject<AadApplicationRegistrationInformationHostConfiguration>();
        }

        /// <summary>
        ///     Gets or sets the standard key divider character ('-').
        ///     <para>
        ///         Whereas AppHost keys can contain ':', etc. -- KeyVault cannot, so
        ///         they must be converted to this character (eg: '-', or '_', or maybe even '')
        ///     </para>
        /// </summary>
        public string KeyStandardNameComponentDivider { get; }

        /// <summary>
        ///     Gets or sets the key illegal characters.
        ///     <para>
        ///         Whereas AppHost keys can contain ':', etc. -- KeyVault cannot, so
        ///         they must be converted to this character (eg: '-', or '_', or maybe even '')
        ///     </para>
        /// </summary>
        /// <value>
        ///     The key illegal characters.
        /// </value>
        public string[] KeyIllegalCharacters { get; }


        /// <summary>
        /// </summary>
        public string KeyPrefix { get; private set; }
    }
}
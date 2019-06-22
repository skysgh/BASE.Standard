// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.DependencyResolution.Lifecycles;
using App.Modules.Core.Shared.Configuration.Settings;

namespace App.Modules.Core.Infrastructure.Services.Configuration.Implementations
{
    /// <summary>
    ///     Configuration object to be injected into the
    ///     implementation of <see cref="IApplicationInformationService" />
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
    public class ApplicationInformationServiceConfiguration : ICoreServiceConfigurationObject
    {
        public ApplicationCreatorInformationConfigurationSettings ApplicationCreatorInformation;

        public ApplicationDistributorInformationConfigurationSettings ApplicationDistributorInformation;

        public ApplicationDescriptionConfigurationSettings ApplicationInformation;

        public ApplicationInformationServiceConfiguration(IAzureKeyVaultService keyVaultService)
        {
            ApplicationInformation = keyVaultService.GetObject<ApplicationDescriptionConfigurationSettings>();
            ApplicationCreatorInformation =
                keyVaultService.GetObject<ApplicationCreatorInformationConfigurationSettings>();
            ApplicationDistributorInformation =
                keyVaultService.GetObject<ApplicationDistributorInformationConfigurationSettings>();
        }
    }
}
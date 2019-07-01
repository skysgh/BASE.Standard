// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.DependencyResolution.Lifecycles;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{
    /// <summary>
    ///     Configuration object to be injected into the
    ///     implementation of <see cref="IApplicationInformationService" />
    ///     <para>
    ///         Inherits from <see cref="IConfigurationObject" />
    ///         whic inherits from <see cref="IHasSingletonLifecycle" />
    ///         to hint at startup that the Configuration object should be
    ///         IoC registered for the duration of the application (not the thread).
    ///         as some configuration hits remote services (eg: Azure KeyVault)
    ///         which would be rather slow.
    ///     </para>
    /// </summary>
    /// <seealso cref="IConfigurationObject" />
    public class ApplicationInformationServiceConfiguration : ConfigurationObjectBase
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
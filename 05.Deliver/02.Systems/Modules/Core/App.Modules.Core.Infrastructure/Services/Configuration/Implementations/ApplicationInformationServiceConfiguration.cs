using App.Modules.Core.Configuration.Settings;
using App.Modules.Core.Shared.Contracts.Lifecycles;

namespace App.Modules.Core.Infrastructure.Services.Configuration.Implementations
{

    /// <summary>
    /// Configuration object to be injected into the 
    /// implementation of <see cref="IApplicationInformationService"/>
    /// <para>
    /// Inherits from <see cref="ICoreServiceConfigurationObject"/>
    /// whic inherits from <see cref="IHasSingletonLifecycle"/>
    /// to hint at startup that the Configuration object should be 
    /// IoC registered for the duration of the application (not the thread).
    /// as some configuration hits remote services (eg: Azure KeyVault)
    /// which would be rather slow.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.Configuration.ICoreServiceConfigurationObject" />
    public class ApplicationInformationServiceConfiguration : ICoreServiceConfigurationObject
    {

        public ApplicationDescriptionConfigurationSettings ApplicationInformation;

        public ApplicationCreatorInformationConfigurationSettings ApplicationCreatorInformation;

        public ApplicationDistributorInformationConfigurationSettings ApplicationDistributorInformation;

        public ApplicationInformationServiceConfiguration(IAzureKeyVaultService keyVaultService)
        {
            this.ApplicationInformation = keyVaultService.GetObject<ApplicationDescriptionConfigurationSettings>();
            this.ApplicationCreatorInformation = keyVaultService.GetObject<ApplicationCreatorInformationConfigurationSettings>();
            this.ApplicationDistributorInformation = keyVaultService.GetObject<ApplicationDistributorInformationConfigurationSettings>();
        }
    }
}
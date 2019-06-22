// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.Services.Configuration.Implementations;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;
using App.Modules.Core.Shared.Configuration.Settings;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IApplicationInformationService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IApplicationInformationService" />
    public class ApplicationInformationService : AppCoreServiceBase, IApplicationInformationService
    {
        private readonly ApplicationInformationServiceConfiguration _applicationInformationServiceConfiguration;

        public ApplicationInformationService(
            ApplicationInformationServiceConfiguration applicationInformationServiceConfiguration)
        {
            _applicationInformationServiceConfiguration = applicationInformationServiceConfiguration;
        }

        public ApplicationDescriptionConfigurationSettings GetApplicationInformation()
        {
            return _applicationInformationServiceConfiguration.ApplicationInformation;
        }

        public ApplicationCreatorInformationConfigurationSettings GetApplicationCreatorInformation()
        {
            return _applicationInformationServiceConfiguration.ApplicationCreatorInformation;
        }

        public ApplicationDistributorInformationConfigurationSettings GetApplicationDistributorInformation()
        {
            return _applicationInformationServiceConfiguration.ApplicationDistributorInformation;
        }
    }
}
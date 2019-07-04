// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Configuration.Services;
using App.Modules.Core.Infrastructure.Configuration.Settings;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IApplicationDescriptionService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IApplicationDescriptionService" />
    public class ApplicationDescriptionService : AppCoreServiceBase, IApplicationDescriptionService
    {
        private readonly ApplicationDescription _applicationInformationServiceConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDescriptionService"/> class.
        /// </summary>
        /// <param name="applicationInformationServiceConfiguration">The application information service configuration.</param>
        public ApplicationDescriptionService(
            ApplicationDescription applicationInformationServiceConfiguration)
        {
            _applicationInformationServiceConfiguration 
                = applicationInformationServiceConfiguration;
        }

        public ApplicationDescription GetApplicationInformation()
        {
            return _applicationInformationServiceConfiguration;
        }
    }
}
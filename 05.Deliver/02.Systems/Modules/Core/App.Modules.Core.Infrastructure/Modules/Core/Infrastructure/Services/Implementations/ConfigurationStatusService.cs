using System.Linq;
using App.Modules.All.Infrastructure.Exceptions;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Services.Statuses;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Contract for an Infrastructure Service to
    ///     manage the recording of information as to whether
    ///     services were configured or not, so 
    ///     
    ///     that can later be queried by Application and Infrastructure
    ///     Support Specialists, via appropriate APIs.
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IConfigurationStatusService" />
    public class ConfigurationStatusService : IConfigurationStatusService
    {
        private readonly IDependencyResolutionService _dependencyResolutionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationStatusService"/> class.
        /// </summary>
        /// <param name="dependencyResolutionService">The dependency resolution service.</param>
        public ConfigurationStatusService(IDependencyResolutionService dependencyResolutionService)
        {
            this._dependencyResolutionService = dependencyResolutionService;
        }
        /// <summary>
        /// Gets the queryable set
        /// of (mem) cached singleton instances of
        /// <see cref="ConfigurationStatusStep" />
        /// that were developed throughout the app
        /// to record whether services were correctly configured or not.
        /// <para>
        /// Invoked via the Service Facade.
        /// </para>
        /// </summary>
        /// <returns></returns>
        public IQueryable<ConfigurationStatusBase> Get()
        {
            IQueryable<ConfigurationStatusBase> results;
            try
            {
                results = _dependencyResolutionService
                    .GetAllInstances<IConfigurationStatus>()
                    .Select(x => x as ConfigurationStatusBase)
                    .OrderByDescending(x => x.DisplayOrderHint)
                    .ThenByDescending(x => x.Title)
                    .AsQueryable();
            }
            catch
            {
                throw new ConfigurationException(
                    "Probably have a class inheriting directly from IConfigurationStatus, and not from ConfigurationStatusBase.");
            }

            return results;
        }
    }
}

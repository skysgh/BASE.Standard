// Copyright MachineBrains, Inc. 2019

using System.Linq;
using App.Modules.All.Infrastructure.Services;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Services.Statuses;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for an Infrastructure Service to
    ///     manage the recording of information as to whether
    ///     services were configured or not, so 
    ///     
    ///     that can later be queried by Application and Infrastructure
    ///     Support Specialists, via appropriate APIs.
    /// </summary>
    /// <seealso cref="IInfrastructureService" />
    public interface IConfigurationStatusService : IInfrastructureService
    {

        /// <summary>
        /// Gets the queryable set
        /// of (mem) cached singleton instances of
        /// <see cref="ConfigurationStatusComponentStep" />
        /// that were developed throughout the app
        /// to record whether services were correctly configured or not.
        /// <para>
        /// Invoked via the Service Facade.
        /// </para>
        /// </summary>
        /// <returns></returns>
        IQueryable<ConfigurationStatusComponentBase> GetComponents();


        IQueryable<ConfigurationStatus> Get();

    }
}
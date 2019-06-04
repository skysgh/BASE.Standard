using App.Modules.Core.Models.Messages;
using App.Modules.Core.Models.Messages.Enums;

namespace App.Modules.Core.Infrastructure.Services
{
    using System.Linq;

    /// <summary>
    /// Contract for an Infrastructure Service to 
    /// manage the recording of Setup Configuration Steps
    /// that can later be queried by Application and Infrastructure
    /// Support Speialists, via appropriate APIs.
    /// </summary>
    /// <seealso cref="IModuleSpecificService" />
    public interface IConfigurationStepService : IModuleSpecificService
    {
        /// <summary>
        /// Registers the specified <see cref="ConfigurationStepRecord"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="status">The status.</param>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        void Register(ConfigurationStepType type, ConfigurationStepStatus status, string title, string description);

        /// <summary>
        /// Gets the (mem) cached <see cref="ConfigurationStepRecord"/>s.
        /// <para>
        /// Invoked via the Service Facade.
        /// </para>
        /// </summary>
        /// <returns></returns>
        IQueryable<ConfigurationStepRecord> Get();
    }
}
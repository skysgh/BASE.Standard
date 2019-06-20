using System;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface ISessionService : IInfrastructureService
    {
        /// <summary>
        /// Creates a new Session, associated to the specified Principal.
        /// </summary>
        /// <param name="principal">The principal.</param>
        /// <param name="uniqueCacheId">The unique cache identifier.</param>
        /// <param name="timespanToCache">The timespan to cache.</param>
        /// <returns></returns>
        Session Create(Principal principal, string uniqueCacheId, TimeSpan? timespanToCache = null);

        /// <summary>
        /// Creates a new Session, associated to the specified Principal,
        /// persisted immediately.
        /// </summary>
        /// <param name="principal">The principal.</param>
        /// <param name="uniqueCacheId">The unique cache identifier.</param>
        /// <param name="timespanToCache">The timespan to cache.</param>
        /// <returns></returns>
        Session CreateAndSave(Principal principal, string uniqueCacheId, TimeSpan? timespanToCache = null);

        /// <summary>
        /// Gets the <see cref="Session"/>
        /// using the given unique cache identifier.
        /// </summary>
        /// <param name="uniqueCacheId">The unique cache identifier.</param>
        /// <param name="timespanToCache">The timespan to cache.</param>
        /// <returns></returns>
        Session Get(string uniqueCacheId, TimeSpan? timespanToCache = null);
    }
}

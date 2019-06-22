// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for a service to manage Principal *Records*
    ///     (not the same thing as what the
    ///     <see cref="IPrincipalService" /> does,
    ///     which is really only concerned with managing the Principal
    ///     on the current Thread.
    /// </summary>
    public interface IPrincipalManagmentService : IInfrastructureService
    {
        Principal Get(Guid id);

        /// <summary>
        ///     Gets the Principal, based on the Key/Id the
        ///     external IdP uses to reference the user (won't be the
        ///     same as the Principal record's Id).
        /// </summary>
        /// <returns></returns>
        Principal Get(string idpPrincipalKey, string subPrincipalKey, string uniqueCacheId,
            TimeSpan? timespanToCache = null);


        Principal CreateIfNotExists(string idpPrincipalKey, string subPrincipalKey, string name,
            string uniqueCacheId, TimeSpan? timespanToCache = null);
    }
}
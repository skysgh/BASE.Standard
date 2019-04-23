﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Infrastructure.Services
{
    using App.Modules.Core.Shared.Models.Entities;

    /// <summary>
    /// Contract for a service to manage Principal *Records*
    /// (not the same thing as what the 
    /// <see cref="IPrincipalService"/> does,
    /// which is really only concerned with managing the Principal
    /// on the current Thread.
    /// </summary>
    public interface IPrincipalManagmentService
    {
        Principal Get(Guid id);

        /// <summary>
        /// Gets the Principal, based on the Key/Id the 
        /// external IdP uses to reference the user (won't be the 
        /// same as the Principal record's Id).
        /// </summary>
        /// <returns></returns>
        Principal Get(string idpPrincipalKey, string subPrincipalKey, string uniqueCacheId,
            TimeSpan? timespanToCache = null);


        Principal CreateIfNotExists(string idpPrincipalKey, string subPrincipalKey, string name,
            string uniqueCacheId, TimeSpan? timespanToCache = null);


    }
}

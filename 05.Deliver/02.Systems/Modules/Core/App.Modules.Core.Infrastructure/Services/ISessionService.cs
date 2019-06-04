using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Modules.Core.Models.Entities;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface ISessionService : IModuleSpecificService
    {
        Session Create(Principal principal, string uniqueCacheId, TimeSpan? timespanToCache = null);

        Session CreateAndSave(Principal principal, string uniqueCacheId, TimeSpan? timespanToCache = null);

        Session Get(string uniqueCacheId, TimeSpan? timespanToCache = null);
    }
}

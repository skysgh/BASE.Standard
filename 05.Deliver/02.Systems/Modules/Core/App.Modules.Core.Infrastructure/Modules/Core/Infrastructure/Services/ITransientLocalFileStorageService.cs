using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    /// Contract for a service to store files 
    /// on the host.
    /// THIS IS ONLY VALID FOR LOCAL DEBUGGING AS CLOUD SERVICES
    /// DO NOT GUARANTEE THAT THE APP IS RESTARTED ON THE SAME
    /// SERVER (both a source of bug and security issues)
    /// </summary>
    public interface ITransientLocalFileStorageService : IInfrastructureService
    {
        void Persist(byte[] bytes, string fileName);
    }
}

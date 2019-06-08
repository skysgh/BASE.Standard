using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IStorageService : IInfrastructureService
    {
        void Persist(byte[] bytes, string fileName);
    }
}

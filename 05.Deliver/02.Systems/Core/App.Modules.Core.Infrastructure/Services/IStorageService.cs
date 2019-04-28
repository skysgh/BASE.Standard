using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IStorageService : IAppModuleCoreService
    {
        void Persist(byte[] bytes, string fileName);
    }
}

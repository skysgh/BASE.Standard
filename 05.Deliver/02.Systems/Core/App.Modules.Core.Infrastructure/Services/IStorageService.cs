using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IStorageService : IModuleSpecificService
    {
        void Persist(byte[] bytes, string fileName);
    }
}

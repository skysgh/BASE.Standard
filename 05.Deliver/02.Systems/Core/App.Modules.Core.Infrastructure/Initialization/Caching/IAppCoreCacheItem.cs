using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Infrastructure.Cache
{
    public interface IAppCoreCacheItem
    {
        object Get();
        // TODO: abstract T Get(string subKey);
    }

}

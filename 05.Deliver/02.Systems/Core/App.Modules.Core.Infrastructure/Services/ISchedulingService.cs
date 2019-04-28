using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Infrastructure.Services
{
    // Contract to manage scheduled services without requiring 
    // a separate device (webworker, etc.)
    public interface ISchedulingService : IAppModuleCoreService
    {
    }
}

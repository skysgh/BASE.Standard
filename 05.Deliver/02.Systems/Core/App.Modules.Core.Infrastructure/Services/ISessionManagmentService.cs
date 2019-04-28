using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Modules.Core.Infrastructure.Services.Implementations;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface ISessionManagmentService : IAppModuleCoreService
    {
        void SaveSessionOperationAsync(SessionOperation sessionOperation, IPrincipalService principalService);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Implementations;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface ISessionManagmentService : IInfrastructureService
    {
        void SaveSessionOperationAsync(SessionOperation sessionOperation, IPrincipalService principalService);
    }
}

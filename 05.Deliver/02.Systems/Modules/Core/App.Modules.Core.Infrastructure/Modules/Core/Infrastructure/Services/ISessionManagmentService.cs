// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface ISessionManagmentService : IInfrastructureService
    {
        void SaveSessionOperationAsync(SessionOperation sessionOperation, IPrincipalService principalService);
    }
}
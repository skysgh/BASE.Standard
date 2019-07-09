// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Models;

namespace App.Modules.All.Infrastructure.Services
{
    public interface
        IRemoteServiceClientInfrastructureService : IInfrastructureService,
            IHasPing
    {

    }
}
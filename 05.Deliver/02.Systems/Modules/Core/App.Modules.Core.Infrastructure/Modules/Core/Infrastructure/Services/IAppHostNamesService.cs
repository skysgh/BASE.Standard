// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IAppHostNamesService : IInfrastructureService
    {
        string[] GetAppHostNamesList();

        string[] GetRoutesList();
    }
}
// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IGeoIPService : IInfrastructureService
    {
        GeoInformation Get(string ip);
    }
}
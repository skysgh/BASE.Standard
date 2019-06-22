// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    // Contract to manage scheduled services without requiring 
    // a separate device (webworker, etc.)
    public interface ISchedulingService : IInfrastructureService
    {
    }
}
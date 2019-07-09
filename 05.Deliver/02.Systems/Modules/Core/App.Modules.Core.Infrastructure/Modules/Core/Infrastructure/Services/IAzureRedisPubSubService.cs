// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IAzureRedisPubSubService : IRemoteServiceClientInfrastructureService, IAzureService
    {
        // See: https://www.codeproject.com/Articles/846564/Azure-Redis-Cache

        void Subscribe(string key, Action<string, string> onReceive);
        void Publish(string key, string message);
    }
}
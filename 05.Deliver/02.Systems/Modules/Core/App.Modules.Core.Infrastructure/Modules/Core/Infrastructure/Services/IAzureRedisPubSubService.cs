using System;
using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IAzureRedisPubSubService : IInfrastructureService, IAzureService
    {
        // See: https://www.codeproject.com/Articles/846564/Azure-Redis-Cache

        void Subscribe(string key, Action<string, string> onReceive);
        void Publish(string key, string message);

    }
}

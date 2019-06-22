// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.ServiceAgents;
using StackExchange.Redis;

namespace App.Modules.Core.Infrastructure.ServiceAgents
{
    public interface IAzureRedisServiceAgent : IContextScopedServiceAgent
    {
        ConnectionMultiplexer ConnectionMultiplexer { get; }

        IDatabase Database { get; }

        bool Enabled { get; }
    }
}
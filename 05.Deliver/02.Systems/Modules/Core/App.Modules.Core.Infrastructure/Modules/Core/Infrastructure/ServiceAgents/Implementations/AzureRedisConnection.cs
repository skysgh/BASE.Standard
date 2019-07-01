// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.Core.Infrastructure.Configuration.Services;
using StackExchange.Redis;

namespace App.Modules.Core.Infrastructure.ServiceAgents.Implementations
{
    public class AzureRedisConnection : IAzureRedisServiceAgent
    {
        private Guid _id;


        public AzureRedisConnection(AzureRedisCacheServiceConfiguration azureRedisCacheServiceConfiguration)
        {
            var configurationOptions = ConfigurationOptions.Parse(azureRedisCacheServiceConfiguration.ConnectionString);

            configurationOptions.ClientName = "...";
            configurationOptions.AllowAdmin = false;
            configurationOptions.Ssl = true;
            _id = Guid.NewGuid();
            Enabled = azureRedisCacheServiceConfiguration.Enabled;
            if (Enabled)
            {
                ConnectionMultiplexer = ConnectionMultiplexer.Connect(configurationOptions);
            }
        }

        public bool Enabled { get; }

        public ConnectionMultiplexer ConnectionMultiplexer { get; }

        public IDatabase Database => ConnectionMultiplexer.GetDatabase();
    }
}
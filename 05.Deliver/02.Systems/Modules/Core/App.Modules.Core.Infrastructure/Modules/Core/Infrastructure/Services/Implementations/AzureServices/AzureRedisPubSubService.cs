//// Copyright MachineBrains, Inc. 2019

//using System;
//using App.Modules.Core.Infrastructure.ServiceAgents;

//namespace App.Modules.Core.Infrastructure.Services.Implementations.AzureServices
//{
//    public class AzureRedisPubSubService : IAzureRedisPubSubService
//    {
//        private readonly IAzureRedisServiceAgent _azureRedisConnection;


//        public AzureRedisPubSubService(IAzureRedisServiceAgent azureRedisConnection)
//        {
//            _azureRedisConnection = azureRedisConnection;
//        }


//        public void Subscribe(string key, Action<string, string> onReceive)
//        {
//            var sub = _azureRedisConnection.ConnectionMultiplexer.GetSubscriber();

//            sub.Subscribe("messages", (channel, message) => { onReceive.Invoke(channel, message); });
//        }

//        public void Publish(string key, string message)
//        {
//            var sub = _azureRedisConnection.ConnectionMultiplexer.GetSubscriber();
//            sub.Publish(key, message);
//        }
//    }
//}
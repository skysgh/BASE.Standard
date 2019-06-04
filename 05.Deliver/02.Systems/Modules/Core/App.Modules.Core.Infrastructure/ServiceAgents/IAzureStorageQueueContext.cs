using Microsoft.Azure.Storage.Queue;

namespace App.Modules.Core.Infrastructure.ServiceAgents
{
    public interface IAzureStorageQueueContext
    {
        CloudQueueClient Client
        {
            get;
        }

    }
}
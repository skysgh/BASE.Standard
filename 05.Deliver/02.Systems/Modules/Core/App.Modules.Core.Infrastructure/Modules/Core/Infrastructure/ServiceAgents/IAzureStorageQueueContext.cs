using App.Modules.All.Infrastructure.ServiceAgents;
using Microsoft.Azure.Storage.Queue;

namespace App.Modules.Core.Infrastructure.ServiceAgents
{
    public interface IAzureStorageQueueContext: IContextScopedServiceAgent
    {
        CloudQueueClient Client
        {
            get;
        }

    }
}
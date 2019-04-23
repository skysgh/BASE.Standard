namespace App.Modules.Core.Infrastructure.Integration.Azure.Storage
{
    using Microsoft.Azure.Storage.Queue;

    public interface IAzureStorageQueueContext
    {
        CloudQueueClient Client
        {
            get;
        }

    }
}


using App.Modules.All.Infrastructure.ServiceAgents;
using Microsoft.Azure.Storage.Blob;

namespace App.Modules.Core.Infrastructure.ServiceAgents
{
    public interface IAzureStorageBlobContext: IContextScopedServiceAgent
    {

        CloudBlobClient Client { get; }

        CloudBlobContainer GetContainer(string containerName);

        void EnsureContainer(CloudBlobContainer cloudBlobContainer, BlobContainerPublicAccessType blobContainerPublicAccessType = BlobContainerPublicAccessType.Off);
    }
}

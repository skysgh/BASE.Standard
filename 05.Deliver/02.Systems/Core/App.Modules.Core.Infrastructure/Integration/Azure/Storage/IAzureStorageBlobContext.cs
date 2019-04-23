

namespace App.Modules.Core.Infrastructure.Integration.Azure.Storage
{
    using Microsoft.Azure.Storage.Blob;

    public interface IAzureStorageBlobContext
    {

        CloudBlobClient Client { get; }

        CloudBlobContainer GetContainer(string containerName);

        void EnsureContainer(CloudBlobContainer cloudBlobContainer, BlobContainerPublicAccessType blobContainerPublicAccessType = BlobContainerPublicAccessType.Off);
    }
}

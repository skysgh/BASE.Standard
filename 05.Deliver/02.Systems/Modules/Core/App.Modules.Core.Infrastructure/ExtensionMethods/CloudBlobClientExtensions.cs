using Microsoft.Azure.Storage.Blob;

namespace App
{
    public static class CloudBlobClientExtensions
    {
        public static CloudBlobContainer GetContainer(this CloudBlobClient cloudBlobClient, string containerName, bool ensureExists = true, BlobContainerPublicAccessType BlobContainerPublicAccessTypeIfNew = BlobContainerPublicAccessType.Blob)
        {
            // Retrieve a reference to a container.
            var result = cloudBlobClient.GetContainerReference(containerName);

            //Does not gurantee it exists:
            if (!ensureExists)
            {
                return result;
            }

            result.EnsureContainer(BlobContainerPublicAccessTypeIfNew);
            return result;
        }

    }
}

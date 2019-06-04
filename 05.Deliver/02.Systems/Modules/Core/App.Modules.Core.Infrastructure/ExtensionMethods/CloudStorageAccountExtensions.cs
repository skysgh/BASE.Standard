using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace App.Modules.Core.Infrastructure.ExtensionMethods
{
    public static class CloudStorageAccountExtensions
    {
        public static CloudBlobClient BuildCloudBlobClient(this CloudStorageAccount cloudStorageAccount)
        {
            var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            return cloudBlobClient;
        }
    }
}

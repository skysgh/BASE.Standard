// Copyright MachineBrains, Inc. 2019

using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace App
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
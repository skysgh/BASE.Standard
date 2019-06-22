// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using Microsoft.Azure.Storage.Blob;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for an Infrastructure Service to
    ///     manage access to Azure Storage Accounts
    ///     and the Storage Containers and Blobs within.
    /// </summary>
    public interface IAzureBlobStorageService : IInfrastructureService, IAzureService
    {
        //AzureBlobStorageServiceConfiguration Configuration
        //{
        //    get;
        //}

        void EnsureContainer(string storageAccountContextKey, string containerName,
            BlobContainerPublicAccessType BlobContainerPublicAccessTypeIfNew = BlobContainerPublicAccessType.Blob);

        void UploadAText(string storageAccountContextKey, string containerName, string remoteBlobName, string text);

        string DownloadAText(string storageAccountContextKey, string containerName, string remoteBlobBame);

        void UploadAFile(string storageAccountContextKey, string containerName, string localFilePath);


        //void Persist(byte[] bytes, string targetRelativePath);
        //void Persist(Stream contents, string targetRelativePath);
    }
}
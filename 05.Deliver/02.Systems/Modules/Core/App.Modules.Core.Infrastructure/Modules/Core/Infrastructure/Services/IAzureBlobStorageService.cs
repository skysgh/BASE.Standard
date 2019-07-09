// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using App.Modules.All.Shared.Attributes;
using Microsoft.Azure.Storage.Blob;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for an Infrastructure Service to
    ///     manage access to Azure Storage Accounts
    ///     and the Storage Containers and Blobs within.
    /// </summary>
    [TitleDescription("Azure Blob Configuration",
        "Service to persist media uploaded by end users (after it has been passed through a malware detection service (note that prior to the advent of cloud services, media used to be persisted to the file system).",
        "Settings are set in both the Host Settings(AppSettings) and KeyVault."
    )]
    public interface IAzureBlobStorageService : IRemoteServiceClientInfrastructureService, IAzureService
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
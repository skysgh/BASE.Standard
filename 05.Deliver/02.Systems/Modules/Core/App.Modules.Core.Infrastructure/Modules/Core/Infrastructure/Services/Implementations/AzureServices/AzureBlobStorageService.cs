// Copyright MachineBrains, Inc. 2019

using System.IO;
using App.Modules.Core.Infrastructure.Constants.Storage;
using App.Modules.Core.Infrastructure.DependencyResolution;
using App.Modules.Core.Infrastructure.ServiceAgents;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace App.Modules.Core.Infrastructure.Services.Implementations.AzureServices
{
    /// <summary>
    ///     Dependencies:
    ///     * Nuget Packages:
    ///     * WindowsAzure.Storage" version="8.6.0"
    ///     * Microsoft.sAzure.ConfigurationManager" version="3.2.3"
    /// </summary>
    public class AzureBlobStorageService : AppCoreServiceBase, IAzureBlobStorageService
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        //public AzureBlobStorageServiceConfiguration Configuration { get; private set; }

        public AzureBlobStorageService(IDiagnosticsTracingService diagnosticsTracingService
            /*,AzureBlobStorageServiceConfiguration configuration*/
        )
        {
            _diagnosticsTracingService = diagnosticsTracingService;
            // In this case, the configuration doesn't have much/any settings (it's all in the Context objects).
            //Configuration = configuration;
        }

        public void EnsureContainer(string storageAccountContextKey, string containerName,
            BlobContainerPublicAccessType BlobContainerPublicAccessTypeIfNew = BlobContainerPublicAccessType.Blob)
        {
            var storageAccountContext = GetStorageAccountContext(storageAccountContextKey);

            var result = storageAccountContext.Client.GetContainerReference(containerName);

            result.EnsureContainer(BlobContainerPublicAccessTypeIfNew);
        }


        public void UploadAText(string storageAccountContextKey, string containerName, string remoteBlobName,
            string text)
        {
            var storageAccountContext = GetStorageAccountContext(storageAccountContextKey);
            var cloudBlobContainer = storageAccountContext.GetContainer(containerName);

            var blob =
                cloudBlobContainer.GetBlockBlobReference(remoteBlobName);

            // It's faster to try to upload, and fallback to making the container if need be:
            try
            {
                blob.UploadText(text);
            }
#pragma warning disable 168
            catch (StorageException e)
#pragma warning restore 168
            {
                _diagnosticsTracingService.Trace(TraceLevel.Error,
                    $"Container '{containerName}' does not exist to upload to.");
            }
        }


        public string DownloadAText(string storageAccountContextKey, string containerName, string remoteBlobBame)
        {
            var storageAccountContext = GetStorageAccountContext(storageAccountContextKey);
            var cloudBlobContainer = storageAccountContext.GetContainer(containerName);

            var blob =
                cloudBlobContainer.GetBlockBlobReference(remoteBlobBame);

            var result = blob.DownloadText();

            return result;
        }

        public void UploadAFile(string storageAccountContextKey, string containerName, string localFilePath)
        {
            var storageAccountContext = GetStorageAccountContext(storageAccountContextKey);
            var cloudBlobContainer = storageAccountContext.GetContainer(containerName);

            var remoteFileName = Path.GetFileName(localFilePath);

            // It's faster to try to upload, and fallback to making the container if need be:
            CloudBlockBlob blob;
            blob = cloudBlobContainer.GetBlockBlobReference(remoteFileName);
            try
            {
                blob.UploadFromFile(localFilePath);
            }
#pragma warning disable 168
            catch (StorageException e)
#pragma warning restore 168
            {
                _diagnosticsTracingService.Trace(TraceLevel.Error,
                    $"Container '{containerName}' does not exist to upload to.");
            }
        }


        /// <summary>
        ///     Use Service Locator to return specified context.
        /// </summary>
        /// <param name="storageAccountContextKey">The storage account context key.</param>
        /// <returns></returns>
        private IAzureStorageBlobContext GetStorageAccountContext(string storageAccountContextKey)
        {
            // If no name given, fall back to the default one:
            if (string.IsNullOrWhiteSpace(storageAccountContextKey))
            {
                storageAccountContextKey = StorageAccountNames.Default;
            }

            var result = DependencyLocator.Current.GetInstance<IAzureStorageBlobContext>(storageAccountContextKey);

            return result;
        }


        //        public void Persist(byte[] bytes, string targetRelativePath)
        //        {
        //            using (MemoryStream stream = new MemoryStream(bytes))
        //            {
        //                {
        //                    Persist(stream, targetRelativePath);
        //                }
        //            }
        //        }

        //        public void Persist(Stream contents, string targetRelativePath)
        //        {

        //            // Retrieve reference to a blob named "myblob".
        //            CloudBlockBlob blockBlob = this._cloudBlobContainer.GetBlockBlobReference(targetRelativePath);

        //            // Create or overwrite the "myblob" blob with contents from a local file.
        //            blockBlob.UploadFromStream(contents);
        //        }
    }
}
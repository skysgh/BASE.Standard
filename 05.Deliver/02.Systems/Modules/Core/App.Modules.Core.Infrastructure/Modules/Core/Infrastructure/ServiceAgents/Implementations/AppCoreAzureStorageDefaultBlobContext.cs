// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using App.Modules.All.Shared.Attributes;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.Constants.Storage;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace App.Modules.Core.Infrastructure.ServiceAgents.Implementations
{
    // End developers care about Containers at best.
    // An App keeps most of its containers in one Service Account.
    // A Container Context

    [Key(/*StorageAccountNames.Default*/"Core.Default")]
    public class DefaultAppCoreAzureStorageBlobContext : IAzureStorageBlobContext
    {
        private static readonly object _lock = new object();

        private static readonly Dictionary<string, CloudBlobContainer> ContainersCache =
            new Dictionary<string, CloudBlobContainer>();

        private static bool ContainersInitialized;
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly string ConnectionString;
        private CloudBlobClient _client;


        /// <summary>
        ///     Initializes a new instance of the <see cref="DefaultAppCoreAzureStorageBlobContext" /> class.
        /// </summary>
        /// <param name="keyVaultService">The key vault service.</param>
        public DefaultAppCoreAzureStorageBlobContext(
            AzureEnvironmentSettings azureConfiguration,
            DefaultAzureStorageAccountConfiguration configuration,
            IDiagnosticsTracingService diagnosticsTracingService)
        {
            _diagnosticsTracingService = diagnosticsTracingService;



            if (string.IsNullOrEmpty(configuration.ResourceName))
            {
                configuration.ResourceName = azureConfiguration.DefaultResourceName;
            }

            ConnectionString =
                $"DefaultEndpointsProtocol=https;AccountName={configuration.ResourceName};AccountKey={configuration.ClientSecret};EndpointSuffix=core.windows.net";

            if (!ContainersInitialized)
            {
                CreateContainers();
            }
        }

        public CloudBlobClient Client => _client ?? (_client = Initialize());


        public CloudBlobContainer GetContainer(string containerName)
        {
            // If you don't clean name first you will get a 400
            // when creating the container.
            containerName = CleanContainerName(containerName);

            CloudBlobContainer result = null;

            if (ContainersCache.TryGetValue(containerName, out result))
            {
                return result;
            }

            // Retrieve a reference to a container.
            result = Client.GetContainerReference(containerName);

            //Cache:
            lock (this)
            {
                ContainersCache[containerName] = result;
            }

            return result;
        }

        public void EnsureContainer(CloudBlobContainer container,
            BlobContainerPublicAccessType blobContainerPublicAccessType = BlobContainerPublicAccessType.Off)
        {
            container.CreateIfNotExists(blobContainerPublicAccessType);
        }

        public CloudBlobClient Initialize()
        {
            var cloudStorageAccount = CloudStorageAccount.Parse(ConnectionString);

            return _client = cloudStorageAccount.CreateCloudBlobClient();
        }

        public void CreateContainers()
        {
            lock (_lock)
            {
                try
                {
                    // Develop any known required Containers, with rights as needed:
                    EnsureContainer(GetContainer(BlobStorageContainers.Public),
                        BlobContainerPublicAccessType.Blob);
                    EnsureContainer(GetContainer(BlobStorageContainers.Private));
                    EnsureContainer(GetContainer(BlobStorageContainers.Testing),
                        BlobContainerPublicAccessType.Blob);
                }
                catch (Exception ex)

                {
                    _diagnosticsTracingService.Trace(TraceLevel.Error,
                        ConnectionString); //dont do this normally but am really 
                    _diagnosticsTracingService.Trace(TraceLevel.Error, ex.Message);
                    _diagnosticsTracingService.Trace(TraceLevel.Error, ex.StackTrace);
                    throw;
                }

                ContainersInitialized = true;
            }
        }


        private static string CleanContainerName(string containerName)
        {
            containerName = containerName.ToLower().Substring(0, Math.Min(containerName.Length, 63));

            return containerName;
        }
    }
}
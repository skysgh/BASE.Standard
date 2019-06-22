﻿// Copyright MachineBrains, Inc. 2019

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Modules.Core.Infrastructure.Initialization.Integration.Azure
//{
//    using App.Modules.Core.Infrastructure.Constants.Exceptions;
//    using App.Modules.Core.Infrastructure.Services;
//    using App.Modules.Core.Infrastructure.Services.Configuration.Implementations;
//    using App.Modules.Core.Shared.Models.Configuration;
//    using Microsoft.Azure.Storage;
//    using Microsoft.Azure.Storage.Blob;

//    public class AzureStorageIntegrationInitializer : IHasAppCoreInitializer
//    {
//        private readonly AzureStorageManangementServiceConfiguration _azureStorageServiceConfiguration;

//        //private readonly IAzureStorageManagementService _azureStorageManagementService;

//        public AzureStorageIntegrationInitializer(
//            AzureStorageManangementServiceConfiguration azureStorageServiceConfiguration,
//            IAzureStorageServiceBase azureStorageManagementService)
//        {
//            this._azureStorageServiceConfiguration = azureStorageServiceConfiguration;
//            //this._azureStorageManagementService = azureStorageManagementService;

//        }

//        public void Initialize()
//        {
//            if (string.IsNullOrWhiteSpace(this._azureStorageServiceConfiguration.Configuration.PublicBlobContainerName))
//            {
//                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Azure  Storage Public Blob is not correctly configured (has no value).");
//            }
//            if (string.IsNullOrWhiteSpace(this._azureStorageServiceConfiguration.Configuration.PrivateBlobContainerName))
//            {
//                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Azure  Storage Private Blob is not correctly configured (has no value).");
//            }

//            //TODO_azureStorageServiceConfiguration.AzureStorageAccountConfiguration.

//            //The Application has at least the following storage scenarios:

//            //* Uploaded media that is viewable on the web (if you know the url)
//            //ie: Avatar images, etc.
//            //* Uploaded media that is only downloadable via this app acting as a
//            //stream proxy (ie, classified documents that are not rendered to the web
//            //directly)
//            if (_azureStorageServiceConfiguration.Configuration.EnsureContainers)
//            {
//                EnsureAzureContainers();
//            }
//            else
//            {
//                var publicContainerUrl =
//                    _azureStorageServiceConfiguration.Configuration.Url
//                    + this._azureStorageServiceConfiguration.Configuration.PublicBlobContainerName
//                    + this._azureStorageServiceConfiguration.Configuration.AccountSharedAccessSignatureToken;

//                var blobContainer = new CloudBlobContainer(new Uri(publicContainerUrl));
//                bool check = blobContainer.Exists();


//            }

//        }

//        public void EnsureAzureContainers()
//        {
//            var _storageAccount =
//                CloudStorageAccount.Parse(_azureStorageServiceConfiguration.Configuration.ConnectionString);

//            var cloudBlobClient = _storageAccount.CreateCloudBlobClient();

//            EnsureContainer(cloudBlobClient, _azureStorageServiceConfiguration.Configuration.PublicBlobContainerName,
//                BlobContainerPublicAccessType.Blob);

//            EnsureContainer(cloudBlobClient, _azureStorageServiceConfiguration.Configuration.PrivateBlobContainerName,
//                BlobContainerPublicAccessType.Off);
//        }


//        public CloudBlobContainer EnsureContainer(CloudBlobClient cloudBlobClient, string containerName,
//            BlobContainerPublicAccessType accessType)
//        {
//            throw new ToDoException("EnsureContainer");
//            //var cloudBlobContainer = this._azureStorageManagementService.GetContainer(
//            //    cloudBlobClient,
//            //    containerName,
//            //    true,
//            //    //Blob-level public access. Anonymous clients can read blob data within this container, but not container data.
//            //    accessType
//            //);
//            //return null /*cloudBlobContainer*/;
//        }

//    }

//}


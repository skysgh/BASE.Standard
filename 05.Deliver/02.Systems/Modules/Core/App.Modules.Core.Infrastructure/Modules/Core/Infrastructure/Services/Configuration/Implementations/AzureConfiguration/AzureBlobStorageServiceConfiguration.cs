// Copyright MachineBrains, Inc. 2019

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Modules.Core.Infrastructure.Services.Configuration.Implementations
//{
//    using App.Modules.Core.Shared.Models.Configuration;
//    using App.Modules.Core.Shared.Models.ConfigurationSettings;
//    using Microsoft.Azure.Storage;
//    using Microsoft.Azure.Storage.Blob;


//    public class AzureBlobStorageServiceConfiguration : ICoreServiceConfigurationObject
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="AzureBlobStorageServiceConfiguration"/> class.
//        /// </summary>
//        public AzureBlobStorageServiceConfiguration(IAzureKeyVaultService keyVaultService)
//        {

//            var commonConfigurationSettings = keyVaultService.GetObject<AzureCommonConfigurationSettings>();
//            var configuration = keyVaultService.GetObject<AzureDocumentDbConfigurationSettings>();

//            if (string.IsNullOrEmpty(configuration.ResourceName))
//            {
//                configuration.ResourceName = commonConfigurationSettings.RootResourceName;
//            }


//        }
//    }
//}


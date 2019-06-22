// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Contracts;
using App.Modules.Core.Infrastructure.Constants.Storage;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Initialization.Integration
{
    public class IntegrationSpikes : IHasModuleSpecificInitializer
    {
        private readonly IAzureMapsService _azureMapsService;
        private readonly IAzureBlobStorageService _azureStorageAccountBlobStorageService;

        public IntegrationSpikes(
            IAzureBlobStorageService azureStorageAccountBlobStorageService,
            IAzureMapsService azureMapsService
        )
        {
            _azureStorageAccountBlobStorageService = azureStorageAccountBlobStorageService;
            _azureMapsService = azureMapsService;
        }


        public void Initialize()
        {
            var containerName = BlobStorageContainers.Testing;
            var fileName = "foo.txt";


            _azureStorageAccountBlobStorageService.UploadAText(null, containerName, fileName, "bar");

            _azureStorageAccountBlobStorageService.DownloadAText(null, containerName, fileName);


            //var mapresult = _azureMapsService.AddressSearch("18 Upoko Road", "NZ");
            //var mapresult2 = _azureMapsService.AddressSearch("180 Upoko Road", "NZ");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Modules.All.Infrastructure.Contracts;
using App.Modules.Core.Infrastructure.Constants.Storage;

namespace App.Modules.Core.Infrastructure.Initialization.Integration
{
    using App.Modules.Core.Infrastructure.Constants.Storage;
    using App.Modules.Core.Infrastructure.Services;

    public class IntegrationSpikes : IHasModuleSpecificInitializer
    {
        private readonly IAzureBlobStorageService _azureStorageAccountBlobStorageService;
        private readonly IAzureMapsService _azureMapsService;

        public IntegrationSpikes(
            IAzureBlobStorageService azureStorageAccountBlobStorageService,
            IAzureMapsService azureMapsService
            )
        {
            this._azureStorageAccountBlobStorageService = azureStorageAccountBlobStorageService;
            this._azureMapsService = azureMapsService;
        }


        public void Initialize()
        {
            var containerName = BlobStorageContainers.Testing;
            var fileName = "foo.txt";


            this._azureStorageAccountBlobStorageService.UploadAText(null, containerName,fileName,"bar");

            this._azureStorageAccountBlobStorageService.DownloadAText(null, containerName, fileName);




            //var mapresult = _azureMapsService.AddressSearch("18 Upoko Road", "NZ");
            //var mapresult2 = _azureMapsService.AddressSearch("180 Upoko Road", "NZ");


        }

    }
}

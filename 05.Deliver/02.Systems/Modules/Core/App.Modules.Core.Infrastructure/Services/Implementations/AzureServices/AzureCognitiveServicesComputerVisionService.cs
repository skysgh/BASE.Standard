using App.Modules.Core.Infrastructure.Services.Configuration.Implementations;
using App.Modules.Core.Infrastructure.Services.Configuration.Implementations.AzureConfiguration;

namespace App.Modules.Core.Infrastructure.Services.Implementations.AzureServices
{
    public class AzureCognitiveServicesComputerVisionService: AppCoreServiceBase, IAzureCognitiveServicesComputerVisionService
    {

        public AzureCognitiveServicesComputerVisionService(AzureCognitiveServicesComputerVisionServiceConfiguration azureCognitiveServicesComputerVisionServiceConfiguration )
        {

        }
    }
}

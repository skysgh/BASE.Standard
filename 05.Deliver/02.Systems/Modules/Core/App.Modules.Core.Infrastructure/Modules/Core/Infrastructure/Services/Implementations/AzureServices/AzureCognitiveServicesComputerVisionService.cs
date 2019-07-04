// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Configuration.Services;

namespace App.Modules.Core.Infrastructure.Services.Implementations.AzureServices
{
    public class AzureCognitiveServicesComputerVisionService : AppCoreServiceBase,
        IAzureCognitiveServicesComputerVisionService
    {
        public AzureCognitiveServicesComputerVisionService(
            AzureCognitiveServicesComputerVisionServiceConfiguration
                azureCognitiveServicesComputerVisionServiceConfiguration)
        {
        }
    }
}
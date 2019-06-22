// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.Services.Configuration.Implementations.AzureConfiguration;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;

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
// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Configuration;

namespace App.Modules.Core.Infrastructure.Services.Implementations.AzureServices
{
    public class AzureCognitiveServicesComputerVisionService : AppCoreServiceBase,
        IAzureCognitiveServicesComputerVisionService
    {
        private readonly AzureCognitiveServicesComputerVisionServiceConfiguration _configuration;

        public AzureCognitiveServicesComputerVisionService(
            AzureCognitiveServicesComputerVisionServiceConfiguration configuration,
            IConfigurationStatusService configurationStatusService)
        {
            this._configuration = configuration;
        }

        public bool Ping()
        {
            if (!_configuration.Enabled)
            {
                return false;
            }

            try
            {
                return true;
            }
            catch
            {

            }
            return false;
            //throw new System.NotImplementedException();
        }
    }
}
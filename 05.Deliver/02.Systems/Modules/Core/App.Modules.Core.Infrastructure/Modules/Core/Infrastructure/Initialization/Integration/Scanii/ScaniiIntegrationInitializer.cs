using App.Modules.All.Infrastructure.Constants.Actions;
using App.Modules.All.Infrastructure.Constants.Exceptions;
using App.Modules.All.Infrastructure.Contracts;
using App.Modules.All.Infrastructure.Exceptions;

namespace App.Modules.Core.Infrastructure.Initialization.Integration.Scanii
{
    using App.Modules.All.Shared.Initialization;
    using App.Modules.Core.Infrastructure.Services;

    public class ScaniiIntegrationInitializer : IHasModuleSpecificInitializer, IHasInitialize
    {
        private readonly IMediaMalwareDetectionService _mediaMalwareDetectionService;

        public ScaniiIntegrationInitializer(IMediaMalwareDetectionService mediaMalwareDetectionService)
        {
            this._mediaMalwareDetectionService = mediaMalwareDetectionService;
        }

        public void Initialize()
        {
            if (string.IsNullOrWhiteSpace(this._mediaMalwareDetectionService.Configuration.Key))
            {
                throw new ConfigurationException(
                    $"{ExceptionMessages.SystemConfigurationError}: Scanii Key not correctly configured (has no value).");
            }
            if (string.IsNullOrWhiteSpace(this._mediaMalwareDetectionService.Configuration.Secret))
            {
                throw new ConfigurationException(
                    $"{ExceptionMessages.SystemConfigurationError}: Scanii Secret not correctly configured (has no value).");
            }

            {
                if (this._mediaMalwareDetectionService.Configuration.Key.StartsWith(Actions.TODO))
                {
                    throw new ConfigurationException(
                        $"{ExceptionMessages.SystemConfigurationError}: Scanii Key not correctly configured (Starts with TODO).");
                }
                if (this._mediaMalwareDetectionService.Configuration.Secret.StartsWith(Actions.TODO))
                {
                    throw new ConfigurationException(
                        $"{ExceptionMessages.SystemConfigurationError}: Scanii Secret not correctly configured (Starts with TODO).");
                }

            }
        }
    }
}

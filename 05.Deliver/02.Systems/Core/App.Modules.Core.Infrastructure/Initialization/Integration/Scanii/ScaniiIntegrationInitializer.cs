using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Infrastructure.Initialization.Integration.Scanii
{
    using App.Modules.Core.Infrastructure.Constants.Exceptions;
    using App.Modules.Core.Infrastructure.Constants.Todo;
    using App.Modules.Core.Infrastructure.Services;
    using App.Modules.Core.Shared.Contracts;

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
                if (this._mediaMalwareDetectionService.Configuration.Key.StartsWith(Todo.TODO))
                {
                    throw new ConfigurationException(
                        $"{ExceptionMessages.SystemConfigurationError}: Scanii Key not correctly configured (Starts with TODO).");
                }
                if (this._mediaMalwareDetectionService.Configuration.Secret.StartsWith(Todo.TODO))
                {
                    throw new ConfigurationException(
                        $"{ExceptionMessages.SystemConfigurationError}: Scanii Secret not correctly configured (Starts with TODO).");
                }

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Domain.Services;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Application.Services.Implementations
{
    public class ExampleApplicationService : IExampleApplicationService
    {
        private readonly IExampleInfrastructureService _exampleInfrastructureServicem;
        private readonly IExampleDomainService _exampleDomainService;

        public ExampleApplicationService(IExampleInfrastructureService exampleInfrastructureServicem, IExampleDomainService exampleDomainService)
        {
            _exampleInfrastructureServicem = exampleInfrastructureServicem;
            _exampleDomainService = exampleDomainService;
        }

    }
}

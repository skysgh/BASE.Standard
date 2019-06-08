using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.TKWMODULENAME.Domain.Services;
using App.Modules.TKWMODULENAME.Infrastructure.Services;

namespace App.Modules.TKWMODULENAME.Application.Services.Implementations
{
    public class ExampleApplicationService : IExampleApplicationService
    {
        private readonly IExampleInfrastructureService _exampleInfrastructureService;
        private readonly IExampleDomainService _exampleDomainService;

        public ExampleApplicationService(IExampleInfrastructureService exampleInfrastructureService, IExampleDomainService exampleDomainService)
        {
            this._exampleInfrastructureService = exampleInfrastructureService;
            this._exampleDomainService = exampleDomainService;
        }

        public string DoSomething()
        {
            var x = _exampleInfrastructureService.DoSomething();
            var y = _exampleDomainService.DoSomething();

            return $"{x} {y}";
        }
    }
}

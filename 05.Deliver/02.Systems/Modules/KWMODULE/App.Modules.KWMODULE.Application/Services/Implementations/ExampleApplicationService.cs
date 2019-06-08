using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.KWMODULE.Domain.Services;
using App.Modules.KWMODULE.Infrastructure.Services;

namespace App.Modules.KWMODULE.Application.Services.Implementations
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

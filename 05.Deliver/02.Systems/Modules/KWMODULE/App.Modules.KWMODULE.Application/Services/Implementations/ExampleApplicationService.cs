using App.Modules.KWMODULE.Domain.Services;
using App.Modules.KWMODULE.Infrastructure.Services;

namespace App.Modules.KWMODULE.Application.Services.Implementations
{
    /// <summary>
    ///     Implementation of
    ///     <see cref="IExampleApplicationService" />,
    ///     a class invoked by an AppFacade Controller.
    /// </summary>
    /// <seealso cref="App.Modules.KWMODULE.Application.Services.IExampleApplicationService" />
    public class ExampleApplicationService : IExampleApplicationService
    {
        private readonly IExampleDomainService _exampleDomainService;
        private readonly IExampleInfrastructureService _exampleInfrastructureService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExampleApplicationService" /> class.
        /// </summary>
        /// <param name="exampleInfrastructureService">The example infrastructure service.</param>
        /// <param name="exampleDomainService">The example domain service.</param>
        public ExampleApplicationService(IExampleInfrastructureService exampleInfrastructureService,
            IExampleDomainService exampleDomainService)
        {
            _exampleInfrastructureService = exampleInfrastructureService;
            _exampleDomainService = exampleDomainService;
        }

        /// <summary>
        ///     Does something.
        /// </summary>
        /// <returns></returns>
        public string DoSomething()
        {
            var x = _exampleInfrastructureService.DoSomething();
            var y = _exampleDomainService.DoSomething();

            return $"{x} {y}";
        }
    }
}
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Infrastructure.Tests.Services
{
    public class ServiceDependencyServiceTests : TestClassBase
    {

        public ServiceDependencyServiceTests()
        {
        }

        [Xunit.Fact]
        void CanWeGetADependency()
        {
            Common.UnitTestDependencyInjectionInitializer.Initialize();

            var result = 
                DependencyLocator.Current
                .GetInstance<IExampleInfrastructureService>();

            Xunit.Assert.NotNull(result);
        }
    }
}

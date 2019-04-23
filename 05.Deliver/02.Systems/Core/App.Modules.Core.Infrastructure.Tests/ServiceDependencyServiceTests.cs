using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Infrastructure.Tests
{
    public class ServiceDependencyServiceTests
    {

        public ServiceDependencyServiceTests()
        {
            Common.SetupDI.Initialize();
        }

        [Xunit.Fact]
        void CanWeGetADependency()
        {
            Common.SetupDI.Initialize();

            var result = 
                DependencyLocator.Current
                .GetInstance<IExampleInfrastructureService>();

            Xunit.Assert.NotNull(result);
        }
    }
}

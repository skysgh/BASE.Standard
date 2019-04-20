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
                App.Modules.Core.Shared.Factories.ServiceLocator.Current
                .GetInstance<Services.IExampleInfrastructureService>();

            Xunit.Assert.NotNull(result);
        }
    }
}

using App.Modules.Core.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Common.Tests;
using App.Modules.Core.Common.Tests.Attributes;
using App.Modules.Core.Infrastructure.DependencyResolution;

namespace App.Modules.Core.Infrastructure.Tests.Services
{
    public class ServiceDependencyServiceTests : TestClassBase
    {

        public ServiceDependencyServiceTests()
        {
        }

        [SelfNamingFact()]
        public void CanWeGetADependency()
        {
            UnitTestDependencyInjectionInitializer.Initialize();

            var result = 
                DependencyLocator.Current
                .GetInstance<IDiagnosticsTracingService>();

            Xunit.Assert.NotNull(result);
        }
    }
}

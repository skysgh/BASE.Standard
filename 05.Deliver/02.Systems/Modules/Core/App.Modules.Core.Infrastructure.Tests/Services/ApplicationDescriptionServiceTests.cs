using App.Modules.Core.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Common.Tests;
using App.Modules.Core.Common.Tests.Attributes;
using App.Modules.Core.Infrastructure.DependencyResolution;
using FluentAssertions;

namespace App.Modules.Core.Infrastructure.Tests.Services
{
    public class ApplicationDescriptionServiceTests : TestClassBase
    {

        public ApplicationDescriptionServiceTests()
        {
        }

        [SelfNamingFact()]
        public void CanWeGetADependency()
        {
            UnitTestDependencyInjectionInitializer.Initialize();

            var result = 
                DependencyLocator.Current
                .GetInstance<IApplicationDescriptionService>();

            Xunit.Assert.NotNull(result);
        }
        [SelfNamingFact()]
        public void CanWeGetTheApplicationName()
        {
            UnitTestDependencyInjectionInitializer.Initialize();

            // ARRANGE:
            var service =
                DependencyLocator.Current
                    .GetInstance<IApplicationDescriptionService>();
            //ACT:
            var applicationDescription = service.GetApplicationInformation();
            //ASSERT:
            applicationDescription.Name.Should().NotBeEmpty();
            applicationDescription.Name.Should().Be("TestBase");
        }

        [SelfNamingFact()]
        public void CanWeGetTheCreatorInfo()
        {
            UnitTestDependencyInjectionInitializer.Initialize();
            var service =
                DependencyLocator.Current
                    .GetInstance<IApplicationDescriptionService>();
            var applicationDescription = service.GetApplicationInformation();
            applicationDescription.Name.Should().NotBeEmpty();
            applicationDescription.Creator.Name.Should().Be("MachineBrains, Inc.");
        }


        [SelfNamingFact()]
        public void CanWeGetTheDistributorInfo()
        {
            UnitTestDependencyInjectionInitializer.Initialize();

            var service =
                DependencyLocator.Current
                    .GetInstance<IApplicationDescriptionService>();

            var applicationDescription = service.GetApplicationInformation();

            applicationDescription.Name.Should().NotBeEmpty();
            applicationDescription.Distributor.Name.Should().Be("MachineBrains, Inc.");
        }

        
    }
}

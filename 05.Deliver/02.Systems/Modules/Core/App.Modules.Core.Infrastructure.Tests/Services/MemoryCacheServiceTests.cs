using System;
using System.Threading;
using App.Modules.Core.Common.Tests.Attributes;
using App.Modules.Core.Infrastructure.DependencyResolution;
using FluentAssertions;
using Xunit;

namespace App.Modules.Core.Infrastructure.Tests.Services
{
    public class MemoryCacheServiceTests : TestClassBase
    {
        [SelfNamingFact()]
        public void GetService()
        {
            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IMemoryCachingService>();

            Assert.NotNull(service);
        }
        [SelfNamingFact()]
        public void GetValueDuringDelay()
        {
            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IMemoryCachingService>();

            service.Register("abba", TimeSpan.FromMilliseconds(100), () => 3);

            int result = service.Get<int>("abba");

            result.Should().Be(3);
        }

        [SelfNamingFact()]
        public void GetValueAfterInitialDelay()
        {
            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IMemoryCachingService>();

            service.Register("beta", TimeSpan.FromMilliseconds(100), () => 3);


            Thread.Sleep(150);
            int result = service.Get<int>("beta");
            result.Should().Be(3);
        }

    }
}

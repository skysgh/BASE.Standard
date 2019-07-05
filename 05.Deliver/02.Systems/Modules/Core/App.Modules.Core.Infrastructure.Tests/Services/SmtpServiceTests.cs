using System;
using System.Threading;
using App.Modules.Core.Common.Tests.Attributes;
using App.Modules.Core.Infrastructure.DependencyResolution;
using FluentAssertions;
using Xunit;

namespace App.Modules.Core.Infrastructure.Tests.Services
{
    public class SmtpServiceTests : TestClassBase
    {
        [SelfNamingFact()]
        public void GetService()
        {
            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.ISmtpService>();

            Assert.NotNull(service);
        }



        [SelfNamingFact()]
        public void GetValueDuringDelay()
        {
            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.ISmtpService>();

            try
            {
                service.SendMessage("skys@ministryof.tech", "A Unit Test",
                    "Some simple <b>body</b>.");
                true.Should().Be(true);
            }
#pragma warning disable CS0168 // Variable is declared but never used
#pragma warning disable IDE0059 // Value assigned to symbol is never used
            catch (Exception e)
#pragma warning restore IDE0059 // Value assigned to symbol is never used
#pragma warning restore CS0168 // Variable is declared but never used
            {
                false.Should().Be(true);

            }

        }
    }
}

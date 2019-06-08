using System;
using App.Modules.Core.Infrastructure.Services.Implementations;
using Xunit;

namespace App.Modules.Core.Infrastructure.Tests.Services
{
    public class DateTimeServiceTests : TestClassBase
    {

        [Fact]
        public void DateTimeService_Can_Return_Current_UTC_Date()
        {
            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IUniversalDateTimeService>();

            var result = service.NowUtc();

            Assert.Equal(DateTime.UtcNow.Date, result.Date);
        }


        [Fact]
        public void DateTimeService_Can_Return_Current_UTC_Hour()
        {
            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IUniversalDateTimeService>();

            var result = service.NowUtc();
            //TODO: Test could be refined, but unless this is actually on on the hour, then this will be fine.
            Assert.Equal(DateTime.UtcNow.Hour, result.Hour);
        }

    }
}

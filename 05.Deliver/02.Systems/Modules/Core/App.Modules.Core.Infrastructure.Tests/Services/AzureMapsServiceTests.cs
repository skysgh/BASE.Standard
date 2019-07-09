using System;
using System.Linq;
using App.Modules.Core.Common.Tests.Attributes;
using App.Modules.Core.Infrastructure.DependencyResolution;
using FluentAssertions;
using Xunit;

namespace App.Modules.Core.Infrastructure.Tests.Services
{
    public class AzureMapsServiceTests : TestClassBase
    {

        [SelfNamingFact]
        public void AzureMapsService_Can_Get_Service()
        {
            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IAzureMapsService>();


            service.Should().NotBeNull();
        }


        [SelfNamingFact]
        public void AzureMapsService_Can_Return_Current_Location()
        {
            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IAzureMapsService>();

            
            var result = service.AddressSearch("18 Upoko Road, Wellington","",false);

            var f = result.Results.First();
            f.Address.PostalCode.Should().Be("6021");
        }


        [SelfNamingFact]
        public void AzureMapsService_Can_Return_Current_Nearest_Address()
        {
            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IAzureMapsService>();


            var result = service.ReverseAddressSearch((decimal)-41.29888, (decimal)174.79503);

            var f = result.Addresses.First();
            f.Address.PostalCode.Should().Be("6021");
        }

    }
}

﻿using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using App.Modules.Core.Common.Tests.Attributes;
using App.Modules.Core.Infrastructure.DependencyResolution;
using FluentAssertions;
using Xunit;

namespace App.Modules.Core.Infrastructure.Tests.Services
{
    public class GeoLocationServiceServiceTests : TestClassBase
    {

        [SelfNamingFact]
        public void CanGetGeoLocationService()
        {
            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IGeoLocationService>();


            service.Should().NotBe(null);
        }


        [SelfNamingFact]
        public void GeoLocationServiceService_Does_Not_Stop_Safe_Files()
        {
            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IGeoLocationService>();

            var host = Dns.GetHostEntry(Dns.GetHostName());

            var ip = host.AddressList
                .Where(x => x.AddressFamily == AddressFamily.InterNetwork)
                .FirstOrDefault()?.ToString();

            ip = new WebClient().DownloadString("http://ipinfo.io/ip").Replace("\n","");

            var result = service.Get(ip);

            // Will fail if 50 tries/credits are expired....
            result.CountryName.Should().NotBeEmpty();
        }

    }
}
// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using App.Modules.All.Shared.Attributes;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services
{
    [
        TitleDescription("GeoLocationService",
        "Service to Convert client IPs to city, country, etc.",

        @"Provide 'app:modules:core:GeoLocationServiceConfiguration' settings in the KeyVault defined within the local appsettings.json provided 'app:modules:core:AzureEnvironment'.")]
    public interface IGeoLocationService : IInfrastructureService
    {
        GeoInformation Get(string ip);
    }
}
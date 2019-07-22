// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;

namespace App.Modules.Core.Infrastructure.Services.Configuration
{
    public class GeoLocationServiceConfiguration
        : ServiceClientConfigurationObjectBase
    {
        public GeoLocationServiceConfiguration(
            IConfigurationService configurationService)
        {
            configurationService.Get(this);
        }

    }
}
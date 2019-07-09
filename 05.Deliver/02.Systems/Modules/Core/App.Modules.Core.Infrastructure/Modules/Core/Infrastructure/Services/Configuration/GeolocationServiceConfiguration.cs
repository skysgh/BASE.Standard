// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Configuration.Services
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
// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Models;
using Microsoft.Extensions.DependencyInjection;

namespace App.Modules.All.Infrastructure.DependencyResolution.Conventions
{
    public class ConfigurationStatusRegistrationConvention : DefaultCustomRegistrationConventionBase<IConfigurationStatus> {
        public ConfigurationStatusRegistrationConvention() : base(
            ServiceLifetime.Singleton,true)
        {

        }
    }
}
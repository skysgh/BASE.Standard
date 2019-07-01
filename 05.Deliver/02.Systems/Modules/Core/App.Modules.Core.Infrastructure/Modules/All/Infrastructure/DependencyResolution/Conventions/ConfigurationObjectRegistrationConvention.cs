// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Modules.All.Infrastructure.DependencyResolution.Conventions
{

    public class ConfigurationObjectRegistrationConvention : DefaultCustomRegistrationConventionBase<IConfigurationObject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationOBjectRegistrationConvention" /> class.
        /// </summary>
        public ConfigurationObjectRegistrationConvention() : base(
                    ServiceLifetime.Singleton, true)
        {

        }
    }

}
// Copyright MachineBrains, Inc. 2019

using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace App.Modules.All.Infrastructure.DependencyResolution.Conventions
{
    public class DbContextOptionsBuilderRegistrationConvention
        : DefaultCustomRegistrationConventionBase<IDbContextOptionsBuilderInfrastructure>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextOptionsBuilderRegistrationConvention" /> class.
        /// </summary>
        public DbContextOptionsBuilderRegistrationConvention() : base(
        ServiceLifetime.Singleton, false)
        {

        }
    }
}
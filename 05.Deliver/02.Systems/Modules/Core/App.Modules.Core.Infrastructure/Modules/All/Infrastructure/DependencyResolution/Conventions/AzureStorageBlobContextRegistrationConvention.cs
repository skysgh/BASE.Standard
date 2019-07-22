// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.ServiceAgents;
using Microsoft.Extensions.DependencyInjection;

namespace App.Modules.All.Infrastructure.DependencyResolution.Conventions
{
    public class AzureStorageBlobContextRegistrationConvention :
        DefaultCustomRegistrationConventionBase<IAzureStorageBlobContext>
    {
        public AzureStorageBlobContextRegistrationConvention() : base(
            ServiceLifetime.Scoped, 
            false, 
            "AppCoreAzureStorageBlobContext")
        {

        }

        
    }
}
using App.Modules.Core.Infrastructure.Services.Implementations;
using Lamar;
using System;
using System.IO;
using System.Linq;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace App.Modules.Core.Common
{
    public class UnitTestDependencyInjectionInitializer 
    {


        public static void Initialize()
        {

            new Infrastructure.Initialization.DependencyResolution.ApplicationDependencyResolutionContainerInitializer().Initialize();

        }
    }

}

using App.Modules.All.Infrastructure.DependencyResolution;

namespace App.Modules.Core.Common.Tests
{
    public class UnitTestDependencyInjectionInitializer
    {


        public static void Initialize()
        {

            new DependencyResolutionContainerInitializer().Initialize();


        }
    }

}

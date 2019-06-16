using App.Modules.All.Infrastructure.DependencyResolution;
using Lamar.Scanning.Conventions;

namespace App.Modules.KWMODULE.Infrastructure.DependencyResolution
{
    public class ModuleServiceRegistry : ModuleServiceRegistryBase
    {
        protected override void InnerScan(IAssemblyScanner assemblyScanner)
        {
            base.InnerScan(assemblyScanner);
        }
    }
}
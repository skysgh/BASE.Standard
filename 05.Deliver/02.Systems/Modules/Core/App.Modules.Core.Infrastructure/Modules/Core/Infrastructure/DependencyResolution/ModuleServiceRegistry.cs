using App.Modules.All.Infrastructure.DependencyResolution;
using Lamar.Scanning.Conventions;

namespace App.Modules.Core.Infrastructure.DependencyResolution
{
    public class ModuleServiceRegistry : ModuleServiceRegistryBase
    {
        protected override void InnerScan(IAssemblyScanner assemblyScanner)
        {
            // Nothing else required.
            base.InnerScan(assemblyScanner);
        }
    }
}
using App.Modules.All.Infrastructure.DependencyResolution;
using Lamar.Scanning.Conventions;

namespace App.Modules.KWMODULE.Infrastructure.DependencyResolution
{
    /// <summary>
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.DependencyResolution.ModuleServiceRegistryBase" />
    public class ModuleServiceRegistry : ModuleServiceRegistryBase
    {
        /// <summary>
        ///     <para>
        ///         Invoked by Constructor.
        ///     </para>
        ///     Override to provide Module/Assembly specific scanning rules.
        /// </summary>
        /// <param name="assemblyScanner">The assembly scanner.</param>
        protected override void InnerScan(IAssemblyScanner assemblyScanner)
        {
            base.InnerScan(assemblyScanner);
        }
    }
}
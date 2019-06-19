using App.Modules.All.Application.DependencyResolution;
using Lamar.Scanning.Conventions;

namespace App.Modules.Design.Application.Initialization.DependencyResolution
{
    /// <summary>
    /// Discoverable (by Reflection) Module specific configuration
    /// of the DependencyLocator.
    /// <para>
    /// Note that it is important that these common classes
    /// are just called 'Module'Something and not 'ModuleXXX'Something,
    /// (and just use the Namespace to distinguish between Modules)
    /// so that it is easier to start new development just using Search/Replace
    /// within namespaces (it's easier to find `Module1` within `.Module1`
    /// than find the same thing within `Module1Something`.
    /// </para>
    /// </summary>
    public class ModuleServiceRegistry 
        : ModuleServiceRegistryBase
    {
        /// <summary>
        /// Override to define what to find
        /// and register 
        /// within this logical Module's assemblies.
        /// <para>
        /// Not that it already been scoped to the
        /// logical module's assemblies.
        /// </para>
        /// </summary>
        /// <param name="assemblyScanner">The assembly scanner.</param>
        protected override void InnerScan(IAssemblyScanner assemblyScanner)
        {
            base.InnerScan(assemblyScanner);
        }
    }
}

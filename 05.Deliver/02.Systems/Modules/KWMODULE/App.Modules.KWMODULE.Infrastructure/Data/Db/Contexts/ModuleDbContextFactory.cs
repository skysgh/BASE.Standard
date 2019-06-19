using App.Modules.All.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;

namespace App.Modules.KWMODULE.Infrastructure.Data.Db.Contexts
{
    /// <summary>
    /// <para>
    /// Note that each logical Module requires it's own ModuleDbContext.
    /// </para>
    /// </summary>
    public class ModuleDbContextFactory : ModuleDbContextFactoryBase<ModuleDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ModuleDbContextFactory"/> class.
        /// </summary>
        public ModuleDbContextFactory()
        {
        }
    }
}

using App.Modules.Core.Infrastructure.Data.Db.Contexts;

namespace App.Modules.Core.Infrastructure.Data.Db.Contexts
{
    public class ModuleDbContextFactory
        : ModuleDbContextFactoryBase<ModuleDbContext>
    {
        public ModuleDbContextFactory()
        {
        }
    }
}

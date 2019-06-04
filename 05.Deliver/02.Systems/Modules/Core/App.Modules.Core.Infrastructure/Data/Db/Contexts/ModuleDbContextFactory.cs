using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace App.Modules.Core.Infrastructure.Data.Db.Contexts
{
    /// <summary>
    /// <para>
    /// Note that each logical Module requires it's own ModuleDbContext.
    /// </para>
    /// </summary>
    public class ModuleDbContextFactory : IDesignTimeDbContextFactory<ModuleDbContext>
    {

        public ModuleDbContextFactory()
        {

        }
        public ModuleDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ModuleDbContext>();

            var databaseName = "BASE.JUMP.Dev";
            optionsBuilder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database={databaseName};Trusted_Connection=True;");

            return new ModuleDbContext(optionsBuilder.Options);

        }
    }
}

using App.Modules.All.Infrastructure.Data.Db.Contexts;
using Microsoft.Extensions.Configuration;

namespace App.Modules.Core.Infrastructure.Data.Db.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.Data.Db.Contexts.ModuleDbContextOptionsBuilderBase{ModuleDbContext}" />
    public class ModuleDbContextOptionsBuilder
        : ModuleDbContextOptionsBuilderBase<ModuleDbContext> 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleDbContextOptionsBuilder"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ModuleDbContextOptionsBuilder(IConfiguration configuration)
            : base(configuration)
        {
            //All done by the base class.
            //The default is that the connection string name will be 
            // {ModuleName}{TypeName}. So it will be something like
            // "CoreModuleDbContext", or "FooModuleDbContext".
            // If you want it to be the default one, provide it in the
            // constructor argument.
        }
    }
}

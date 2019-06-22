using App.Modules.All.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Modules.KWMODULE.Infrastructure.Data.Db.Contexts
{
    /// <summary>
    ///     The DbContext to use when the entity being returned
    ///     references entities in this module that have Navigation
    ///     properties that cross over to other Logical Modules
    ///     (and therefore Schemas).
    ///     <para>
    ///         Note that this DbContext's constructor is Dependency
    ///         Injected with DbContexts it references.
    ///     </para>
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.Data.Db.Contexts.ModuleDbContextBase" />
    public class JoinedModuleDbContext : ModuleDbContextBase
    {
        private readonly ModuleDbContext _moduleDbContext;


        /// <summary>
        ///     <para>
        ///         Invoked by Constructor.
        ///     </para>
        ///     This is the constructor invoked by the system's dependency injector/creator.
        /// </summary>
        /// <param name="moduleDbContext">The module database context.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="appDbContextManagementService">The application database context management service.</param>
        public JoinedModuleDbContext(ModuleDbContext moduleDbContext,
            IConfiguration configuration, IAppDbContextManagementService appDbContextManagementService)
            : base(configuration, appDbContextManagementService,
                true)
        {
            // Not really needed, but want to trigger 
            // the creation of tables.
            _moduleDbContext = moduleDbContext;
        }


        /// <summary>
        ///     Note: default behaviour is that it is not called by constructor by default.
        ///     But is called by Migrate.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
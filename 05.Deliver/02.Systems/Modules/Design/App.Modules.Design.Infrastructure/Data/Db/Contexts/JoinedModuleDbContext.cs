// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Modules.Design.Infrastructure.Data.Db.Contexts
{
    /// <summary>
    ///     The Modules's Joined DbContext which
    ///     combines this Modules Schema as well the Core Schema.
    ///     <para>
    ///         Note how the constructor takes two DbContexts
    ///         to do this.
    ///     </para>
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.Data.Db.Contexts.ModuleDbContextBase" />
    public class JoinedModuleDbContext : ModuleDbContextBase
    {
        private readonly ModuleDbContext _moduleDbContext;


        /// <summary>
        ///     This is the constructor invoked by the system's dependency injector/creator.
        /// </summary>
        /// <param name="moduleDbContext">The module database context.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="appDbContextManagementService">The application database context management service.</param>
        public JoinedModuleDbContext(ModuleDbContext moduleDbContext,
            IConfiguration configuration,
            IAppDbContextManagementService appDbContextManagementService)
            : base(
                configuration, 
                appDbContextManagementService,
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
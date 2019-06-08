using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.All.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace App.Modules.KWMODULE.Infrastructure.Data.Db.Contexts
{

    public class JoinedModuleDbContext : ModuleDbContextBase
    {

        private readonly ModuleDbContext _moduleDbContext;


        /// <summary>
        /// This is the constructor invoked by the system's dependency injector/creator.
        /// </summary>
        /// <param name="moduleDbContext">The module database context.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="appDbContextManagementService">The application database context management service.</param>
        public JoinedModuleDbContext(ModuleDbContext moduleDbContext,
            IConfiguration configuration, IAppDbContextManagementService appDbContextManagementService)
            : base(configuration, appDbContextManagementService, 
                isJointTable:true)
        {

            // Not really needed, but want to trigger 
            // the creation of tables.
            this._moduleDbContext = moduleDbContext;

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}

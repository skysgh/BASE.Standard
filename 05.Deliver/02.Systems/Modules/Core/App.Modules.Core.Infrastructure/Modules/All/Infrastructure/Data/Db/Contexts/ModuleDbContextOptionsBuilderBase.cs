using App.Modules.All.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Modules.All.Infrastructure.Data.Db.Contexts
{

    public abstract class ModuleDbContextOptionsBuilderBase<TModuleDbContext>
        : DbContextOptionsBuilder<TModuleDbContext>
        where TModuleDbContext : ModuleDbContextBase
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ModuleDbContextOptionsBuilderBase{TModuleDbContext}" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="connectionStringNameOverride">The connection string name override.</param>
        protected ModuleDbContextOptionsBuilderBase(IConfiguration configuration, string connectionStringNameOverride=null)
        {

            string connectionStringName = connectionStringNameOverride 
                                          ?? $"{Module.Id(GetType())}{GetType().Name}";

            var suffix = "OptionsBuilder";
            if (connectionStringName.Contains(suffix))
            {
                connectionStringName = connectionStringName.Substring(0, connectionStringName.IndexOf(suffix));
            }

            string connectionString = configuration.GetConnectionString(connectionStringName);

            this.UseSqlServer(connectionString);
        }
    }
}

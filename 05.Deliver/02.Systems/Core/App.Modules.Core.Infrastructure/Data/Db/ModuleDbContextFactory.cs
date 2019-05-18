using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace App.Modules.Core.Infrastructure.Data.Db
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

            return new ModuleDbContext( optionsBuilder.Options);

        }
    }
}

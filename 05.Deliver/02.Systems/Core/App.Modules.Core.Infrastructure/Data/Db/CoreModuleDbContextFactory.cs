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
    public class CoreModuleDbContextFactory : IDesignTimeDbContextFactory<CoreModuleDbContext>
    {

        public CoreModuleDbContextFactory()
        {

        }
        public CoreModuleDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CoreModuleDbContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb2;Trusted_Connection=True;");


            return new CoreModuleDbContext( optionsBuilder.Options);
        }
    }
}

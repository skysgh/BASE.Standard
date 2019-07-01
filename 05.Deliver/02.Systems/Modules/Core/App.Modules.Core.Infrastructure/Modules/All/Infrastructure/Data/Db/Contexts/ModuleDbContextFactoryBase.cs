// Copyright MachineBrains, Inc. 2019

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace App.Modules.All.Infrastructure.Data.Db.Contexts
{
    /// <summary>
    ///     <para>
    ///         Note that each logical Module requires it's own ModuleDbContext.
    ///     </para>
    /// </summary>
    public abstract class ModuleDbContextFactoryBase<TModuleDbContext>
        : IDesignTimeDbContextFactory<TModuleDbContext>
        where TModuleDbContext : ModuleDbContextBase
    {
        public TModuleDbContext CreateDbContext(string[] args)
        {

            var _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.Development.json", true, true)
                .AddJsonFile("appsettings.INSECURE.json", true, true)
                .AddJsonFile("appsettings.Development.INSECURE.json", true, true)
                .Build();

            DbContextOptionsBuilder<TModuleDbContext> optionsBuilder
                = new DbContextOptionsBuilder<TModuleDbContext>();

            var databaseName = "BASE.4.Migrations";
            optionsBuilder
                .UseSqlServer(
                $"Server=(localdb)\\mssqllocaldb;Database={databaseName};Trusted_Connection=True;");


            // Does not work, as won't accept arguments, so use old school:
            //return Activator.CreateInstance<TModuleDbContext>(_configuration, optionsBuilder.Options);
            return (TModuleDbContext)Activator.CreateInstance(
                typeof(TModuleDbContext),
                BindingFlags.Public | BindingFlags.Instance,
                default,
                new object[]
                {
                    _configuration,
                    optionsBuilder.Options
                },
                default);
        }
    }
}
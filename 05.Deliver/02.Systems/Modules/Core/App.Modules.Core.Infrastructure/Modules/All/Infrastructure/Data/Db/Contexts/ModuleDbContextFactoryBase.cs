﻿// Copyright MachineBrains, Inc. 2019

using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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
            DbContextOptionsBuilder<TModuleDbContext> optionsBuilder = new DbContextOptionsBuilder<TModuleDbContext>();

            var databaseName = "BASE.JUMP.Dev";

            optionsBuilder.UseSqlServer(
                $"Server=(localdb)\\mssqllocaldb;Database={databaseName};Trusted_Connection=True;");

            //return Activator.CreateInstance<TModuleDbContext>(optionsBuilder.Options);


            return (TModuleDbContext) Activator.CreateInstance(
                typeof(TModuleDbContext),
                BindingFlags.Public | BindingFlags.Instance,
                default,
                new object[] {optionsBuilder.Options},
                default);

            //var bindingFlags = BindingFlags.CreateInstance;
            //Binder binder = new 
            //    return Activator.CreateInstance(this, bindingFlags, binder, new[]{optionsBuilder.Options},null);


            //    return System.Activator.CreateInstance(typeof(TModuleDbContext))
            //return new TModuleDbContext(optionsBuilder.Options);
        }
    }
}
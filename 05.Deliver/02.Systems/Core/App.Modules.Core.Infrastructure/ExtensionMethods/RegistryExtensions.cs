﻿//using StructureMap.Web;

//namespace App
//{
//    using Microsoft.EntityFrameworkCore;
//    using App.Modules.Core.Infrastructure.Factories;
//    using App.Modules.Core.Infrastructure.Initialization.DependencyResolution;
//    using StructureMap;
//    using StructureMap.Configuration.DSL.Expressions;
//    using StructureMap.Web.Pipeline;

//    public static class RegistryExtensions
//    {
//        public static void RegisterDbContextInHttpContext<TDbContext>(this Registry registry, string key)
//            where TDbContext : DbContext, new()
//        {


             

//            if (!PowershellServiceLocatorConfig.Activated)
//            {
//                //Register it under DbContext context, but named:
//                new CreatePluginFamilyExpression<DbContext>(registry,
//                    new HttpContextLifecycle()).HybridHttpOrThreadLocalScoped().Use(y => DbContextFactory.Create<TDbContext>()).Named(key);

//                //Register it under specific TDbContext, without name:
//                new CreatePluginFamilyExpression<TDbContext>(registry,
//                    new HttpContextLifecycle()).HybridHttpOrThreadLocalScoped().Use(y => DbContextFactory.Create<TDbContext>());
//            }
//            else
//            {
//                //Register it under DbContext context, but named:
//                // FIX: replaced HybridLifecycle with HttpContextLifecycle
//                new CreatePluginFamilyExpression<DbContext>(registry,
//                    new HttpContextLifecycle()).HybridHttpOrThreadLocalScoped().Use(y => DbContextFactory.Create<TDbContext>()).Named(key);

//                //Register it under specific TDbContext, without name:
//                new CreatePluginFamilyExpression<TDbContext>(registry,
//                    new HttpContextLifecycle()).HybridHttpOrThreadLocalScoped().Use(y => DbContextFactory.Create<TDbContext>());
//                 /*
//                registry.For<DbContext>().HybridHttpOrThreadLocalScoped().Use(y => DbContextFactory.Create<TDbContext>()).Named(key).Singleton();
//                registry.For<TDbContext>().HybridHttpOrThreadLocalScoped().Use(y => DbContextFactory.Create<TDbContext>()).Named(key).Singleton();
//                registry.For<TDbContext>().HybridHttpOrThreadLocalScoped()
//                    .Use(y => DbContextFactory.Create<TDbContext>()).Singleton();
//                    */
//            };
//        }
//    }
//}
// Copyright MachineBrains, Inc. 2019

//using System;
//using System.Collections.Generic;
//using System.Text;
//using App.Modules.Core.AppFacade.Initialization.Startup;
//using App.Modules.Design.Infrastructure.Initialization.Data.Db;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.EntityFrameworkCore.InMemory;
//using Microsoft.EntityFrameworkCore;
//using Lamar;

//namespace App.Modules.Design.AppFacade.Initialization.Setup
//{
//    public class StartupConfigure : IStartupConfigure
//    {
//        IContainer _container;

//        public StartupConfigure(IContainer container)
//        {
//            _container = container;
//        }
//        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
//        {
//            AppendAServiceRegistry();
//        }


//        /// <summary>
//        /// Some ExtensionMethods (eg: AddDbContext)
//        /// are expecting a ServiceRegistry (IServiceCollection)
//        /// of some kind. 
//        /// </summary>
//        private void AppendAServiceRegistry()
//        {
//            ServiceRegistry serviceRegistry = new ServiceRegistry();
//            // Your extension method of choice goes here...
//            // eg:
//            serviceRegistry.AddDbContext<BookStoreContext>(opt => opt.UseInMemoryDatabase("BookLists"));
//            _container.Configure(serviceRegistry);
//        }
//    }
//}


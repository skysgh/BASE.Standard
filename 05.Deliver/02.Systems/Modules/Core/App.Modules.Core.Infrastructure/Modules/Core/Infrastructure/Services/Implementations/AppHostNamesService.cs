// Copyright MachineBrains, Inc. 2019

//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Modules.Core.Infrastructure.Services.Implementations
//{
//    public class AppHostNamesService : IAppHostNamesService
//    {
//        private readonly HostSectionConfigurationManager _hostConfigurationManager;

//        public AppHostNamesService(HostSectionConfigurationManager hostConfigurationManager)
//        {
//            _hostConfigurationManager = hostConfigurationManager;
//        }
//        /// <summary>
//        /// TODO: Replace this with IAzureResourceMangementService service call
//        /// </summary>
//        public string[] GetAppHostNamesList()
//        {
//            return _hostConfigurationManager.HostNames.Select(x => x.Name).ToArray();
//        }

//        public string[] GetRoutesList()
//        {
//            return _hostConfigurationManager.RoutesToIgnore.Select(x => x.Name).ToArray();
//        }

//    }
//}


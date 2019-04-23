using App.Modules.Core.Infrastructure.Services.Implementations;
using Lamar;
using System;
using App.Modules.Core.Infrastructure.Services;
using Xunit;

namespace App.Modules.Core.Common
{
    public class SetupDI
    {
        public static void Initialize()
        {
            if (_container == null)
            {
                var serviceRegistry = new ServiceRegistry();
                new Infrastructure.Initialization.DependencyResolution.ApplicationDependencyResolutionInitializer().Initialize(serviceRegistry);
                _container = new Container(serviceRegistry);

                _container.GetInstance<IDependencyResolutionService>().Initialize(_container);


                DependencyLocator.Current.Initialize(_container);

                var s1 = _container.WhatDidIScan();
                var s2 = _container.WhatDoIHave();

            }
        }
        private static Container _container;
    }

}

using Lamar;
using System;
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
                new Infrastructure.Initialization.DependencyResolution.CommonInitializer().Initialize(serviceRegistry);
                _container = new Container(serviceRegistry);

                Modules.Core.Shared.Factories.ServiceLocator.SetLocatorProvider(_container);
                var s1 = _container.WhatDidIScan();
                var s2 = _container.WhatDoIHave();

            }
        }
        private static Container _container;
    }

}

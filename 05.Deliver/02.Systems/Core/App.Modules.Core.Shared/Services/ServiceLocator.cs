using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Shared.Factories
{

    /// <summary>
    /// See: https://dotnetcoretutorials.com/2018/05/06/servicelocator-shim-for-net-core/
    /// </summary>
    public class ServiceLocator
    {


        private IServiceProvider _currentServiceProvider;


        public ServiceLocator(IServiceProvider currentServiceProvider)
        {
            _currentServiceProvider = currentServiceProvider;
        }

        public static ServiceLocator Current
        {
            get
            {
                return _current;// new ServiceLocator(ServiceProvider);
            }
        }
        private static ServiceLocator _current;



        public static void SetLocatorProvider(IServiceProvider serviceProvider)
        {
            _current = new ServiceLocator(serviceProvider);
        }

        public object GetInstance(Type serviceType)
        {
            return _currentServiceProvider.GetService(serviceType);
        }


        public TService GetInstance<TService>()
        {
            return _currentServiceProvider.GetService<TService>();
        }
    }
}

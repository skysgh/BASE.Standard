using System;
using System.Collections.Generic;
using Lamar;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{

    public class DependencyResolutionService : IDependencyResolutionService
    {
        public IServiceProvider ServiceProvider
        {
            get
            {
                return DependencyLocator.Current.ServiceProvider;
            }
        }

        public DependencyResolutionService() : base()
        {
            

        }

        public object GetService(Type serviceType)
        {
            return DependencyLocator.Current.GetService(serviceType);
        }

        public object GetInstance(Type serviceType)
        {
            return DependencyLocator.Current.GetService(serviceType);
        }

        public object GetInstance(Type serviceType, string key)
        {
            return DependencyLocator.Current.GetInstance(serviceType, key);
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return DependencyLocator.Current.GetAllInstances(serviceType);
        }

        public TService GetInstance<TService>()
        {
            return DependencyLocator.Current.GetInstance<TService>();
        }

        public TService GetInstance<TService>(string key)
        {
            return DependencyLocator.Current.GetInstance<TService>(key);
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return DependencyLocator.Current.GetAllInstances<TService>();
        }

        public void Initialize(IServiceProvider argument)
        {
            throw new NotImplementedException();
        }

    }

    /// <summary>
    /// See: https://dotnetcoretutorials.com/2018/05/06/servicelocator-shim-for-net-core/
    /// </summary>
    public class DependencyLocator
    {

        public static DependencyLocator Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new DependencyLocator();
                }
                return _current;
            }
        }
        static DependencyLocator _current;

        private static IServiceProvider _serviceProvider;

        public IServiceProvider ServiceProvider
        {
            get => _serviceProvider;
        }

        private static IContainer _container;

        public DependencyLocator()
        {

        }

        public void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _container = (IContainer)serviceProvider;
            if (_current != null)
            {
                if (_current != this)
                {
                    throw new Exception("Should not be reinitilizing DependencyResolutionService.");
                }
            }

            _current = this;
        }


        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public object GetInstance(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public object GetInstance(Type serviceType, string key)
        {
            return _container.GetInstance(serviceType, key);
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            throw new NotImplementedException();
            //return _container.GetAllInstances(serviceType);
        }

        public TService GetInstance<TService>()
        {
            return _container.GetInstance<TService>();
        }

        public TService GetInstance<TService>(string key)
        {
            return _container.GetInstance<TService>(key);
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return _container.GetAllInstances<TService>();
        }


        //        private IContainer GetContainer()
        //        {
        //            IContainer r = StructureMapContainerLocator.Container;
        //            return r;
        //        }
        //        //public void Register<T>(string key)
        //        //{

        //        //    new CreatePluginFamilyExpression<IAppCoreCacheItem>(this,
        //        //            new StructureMap.Pipeline.SingletonLifecycle())
        //        //            .Use(y => (IAppCoreCacheItem)AppDependencyLocator.Current.GetInstance(t)).Named(name);




        //        //}
    }
}

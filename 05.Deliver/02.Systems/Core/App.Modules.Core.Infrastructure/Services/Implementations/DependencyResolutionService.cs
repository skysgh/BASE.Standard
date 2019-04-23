using System;
using System.Collections.Generic;
using System.Text;
using Lamar;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{

    public class DependencyResolutionService : DependencyLocator , IDependencyResolutionService
    {

    }

    /// <summary>
    /// See: https://dotnetcoretutorials.com/2018/05/06/servicelocator-shim-for-net-core/
    /// </summary>
    public class DependencyLocator
    {

        public static DependencyLocator Current
        {
            get { if (_current == null) { _current = new DependencyLocator(); } return _current; }
        }
        static DependencyLocator _current;

        public IServiceProvider ServiceProvider { get; private set; }
        private IContainer _container;

        public void Initialize(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            _container = (IContainer)serviceProvider;
        }


        public object GetService(Type serviceType)
        {
            return _container.GetService(serviceType);
        }

        public object GetInstance(Type serviceType)
        {
            return Current.ServiceProvider.GetService(serviceType);
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

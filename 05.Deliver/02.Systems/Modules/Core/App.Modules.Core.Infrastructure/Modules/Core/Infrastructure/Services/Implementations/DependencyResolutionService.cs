using System;
using System.Collections.Generic;
using App.Modules.Core.Infrastructure.DependencyResolution;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{

    /// <summary>
    /// Implementation of the
    /// <see cref="IDependencyResolutionService"/>
    /// service contract to return instances
    /// associated to types.
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IDependencyResolutionService" />
    public class DependencyResolutionService : IDependencyResolutionService
    {
        /// <summary>
        /// Gets the service provider
        /// <para>
        /// Note: It can be typed to a Lamar IContainer
        /// if need be.
        /// </para>.
        /// </summary>
        public IServiceProvider ServiceProvider
        {
            get
            {
                return DependencyLocator.Current.ServiceProvider;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyResolutionService"/> class.
        /// </summary>
        public DependencyResolutionService() : base()
        {
            

        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return DependencyLocator.Current.GetService(serviceType);
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        public object GetInstance(Type serviceType)
        {
            return DependencyLocator.Current.GetService(serviceType);
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public object GetInstance(Type serviceType, string key)
        {
            return DependencyLocator.Current.GetInstance(serviceType, key);
        }

        /// <summary>
        /// Gets all instances.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return DependencyLocator.Current.GetAllInstances(serviceType);
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        public TService GetInstance<TService>()
        {
            return DependencyLocator.Current.GetInstance<TService>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public TService GetInstance<TService>(string key)
        {
            return DependencyLocator.Current.GetInstance<TService>(key);
        }

        /// <summary>
        /// Gets all instances.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return DependencyLocator.Current.GetAllInstances<TService>();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <param name="argument"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Initialize(IServiceProvider argument)
        {
            throw new NotImplementedException();
        }

    }
}

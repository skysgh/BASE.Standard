// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using Lamar;

namespace App.Modules.Core.Infrastructure.DependencyResolution
{
    /// <summary>
    ///     See: https://dotnetcoretutorials.com/2018/05/06/servicelocator-shim-for-net-core/
    /// </summary>
    public class DependencyLocator
    {
        private static DependencyLocator _current;

        private static IServiceProvider _serviceProvider;

        // The lamar container:
        private static IContainer _container;

        /// <summary>
        ///     Gets the current DependencyLocator
        ///     singleton.
        ///     <para>
        ///         If never invoked before creates a new one
        ///         (although it won't yet be Initialized
        ///         with the <see cref="Initialize" /> method.
        ///     </para>
        /// </summary>
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

        public IServiceProvider ServiceProvider => _serviceProvider;

        /// <summary>
        ///     Initializes this DependencyLocator
        ///     with the Lamar Container
        ///     created during Startup (or by Unit Tests).
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <exception cref="System.Exception">Should not be reinitializing DependencyResolutionService.</exception>
        public void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _container = (IContainer) serviceProvider;

            //if (_current != null) && (serviceProvider !=null)
            //{
            //    if (_current != this)
            //    {
            //        throw new Exception("Should not be reinitializing DependencyResolutionService.");
            //    }
            //}
            //_current = this;
        }


        /// <summary>
        ///     Gets the dependency.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        /// <summary>
        ///     Gets the instance.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        public object GetInstance(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        /// <summary>
        ///     Gets the named dependency.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public object GetInstance(Type serviceType, string key)
        {
            return _container.GetInstance(serviceType, key);
        }

        /// <summary>
        ///     Gets all instances associated to the given type.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            throw new NotImplementedException();
            //return _container.GetAllInstances(serviceType);
        }

        /// <summary>
        ///     Gets the specified instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        public TService GetInstance<TService>()
        {
            return _container.GetInstance<TService>();
        }

        /// <summary>
        ///     Gets the named instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public TService GetInstance<TService>(string key)
        {
            return _container.GetInstance<TService>(key);
        }

        /// <summary>
        ///     Gets all instances.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return _container.GetAllInstances<TService>();
        }
    }
}
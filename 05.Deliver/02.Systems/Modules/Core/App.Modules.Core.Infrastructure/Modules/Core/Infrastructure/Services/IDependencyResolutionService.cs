using System;
using System.Collections.Generic;
using App.Modules.All.Infrastructure.Services;
using App.Modules.All.Shared.Initialization;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    /// Contract for an injectable app specific service to 
    /// solve dependencies, while 
    /// not causing downstream assemblies to have to take a 
    /// reference to the Microsoft Common ServiceLocator
    /// or even the singleton
    /// <see cref="App.Modules.Core.Infrastructure.DependencyResolution.DependencyLocator"/>.
    /// </summary>
    public interface IDependencyResolutionService : IInfrastructureService, IHasInitialize<IServiceProvider>
    {
        /// <summary>
        /// Gets the service provider
        /// <para>
        /// Note: It can be typed to a Lamar IContainer
        /// if need be.
        /// </para>.
        /// </summary>
        IServiceProvider ServiceProvider { get; }


        /// <summary>
        /// Gets an instance
        /// of the registered type.
        /// </summary>
        T GetInstance<T>();
        /// <summary>
        /// Gets an instance
        /// of the registered tagged type.
        /// </summary>
        T GetInstance<T>(string key);
        /// <summary>
        /// Gets an instance
        /// of the registered type.
        /// </summary>
        object GetInstance(Type type);
        /// <summary>
        /// Gets an instance
        /// of the registered tagged type.
        /// </summary>
        object GetInstance(Type type, string key);

        /// <summary>
        /// Gets all instances of the specified type.
        /// </summary>
        IEnumerable<T> GetAllInstances<T>();

        /// <summary>
        /// Gets all instances of the specified type.
        /// </summary>
        IEnumerable<object> GetAllInstances(Type type);
    }
}

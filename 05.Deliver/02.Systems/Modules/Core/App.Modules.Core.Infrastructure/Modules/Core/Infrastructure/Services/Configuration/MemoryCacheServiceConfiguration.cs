using System;
using System.Collections.Generic;
using App.Modules.All.Infrastructure.Configuration;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{
    /// <summary>
    /// Singleton configuration for the implementation
    /// of <c>IMemoryCachingService</c>.
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.Configuration.ConfigurationObjectBase" />
    public class MemoryCacheServiceConfiguration 
        : ConfigurationObjectBase
    {
        static readonly IDictionary<string, object> functions;
        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryCacheServiceConfiguration"/> class.
        /// </summary>
        static MemoryCacheServiceConfiguration()
        {
            functions = new Dictionary<string, object>();
        }
        public void Register<T>(string key, Func<T> callback)
        {
            functions[key] = callback;
        }

        /// <summary>
        /// Checks whether the specified key exists.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            return functions.ContainsKey(key);
        }

        /// <summary>
        /// Gets the registered callback function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public Func<T> Get<T>(string key)
        {
            return functions[key] as Func<T>;
        }

    }
}

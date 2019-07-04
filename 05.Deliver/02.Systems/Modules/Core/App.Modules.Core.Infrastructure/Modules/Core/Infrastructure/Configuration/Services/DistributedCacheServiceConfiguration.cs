// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{
    public class DistributedCacheServiceConfiguration 
        : ConfigurationObjectBase
        , IHasServiceClientSecret
    {
        static readonly IDictionary<string, object> functions;
        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryCacheServiceConfiguration"/> class.
        /// </summary>
        static DistributedCacheServiceConfiguration()
        {
            functions = new Dictionary<string, object>();
        }

        public DistributedCacheServiceConfiguration()
        {

        }

        public DistributedCacheServiceConfiguration(
            AzureCommonConfigurationSettings azureCommonConfigurationSettings,
            IConfigurationService configurationService)
        {

            configurationService.Get(this);
        }

        /// <summary>
        /// Gets or sets the connection string.
        /// <para>
        /// <see cref="ClientSecret"/> will be appended to it
        /// as the password.
        /// </para>
        /// </summary>
        public string ConnectionString { get; set; }

        public string ClientSecret { get; set; }

        public string CompleteConnectionString()
        {
            return $"{ConnectionString}, ssl = true, password = {ClientSecret}";
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
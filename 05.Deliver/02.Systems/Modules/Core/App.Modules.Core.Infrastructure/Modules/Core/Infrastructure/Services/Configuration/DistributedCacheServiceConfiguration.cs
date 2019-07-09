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
            , IHasEnabled
            , IHasBaseUri
            , IHasConnectionString
            , IHasServiceClientIdentifier
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
            IConfigurationService configurationService,
            AzureEnvironmentSettings azureEnvironmentSettings)
        {
            configurationService.Get(this);


            if (this.ResourceName.IsNullOrEmpty())
            {
                this.ResourceName = azureEnvironmentSettings.DefaultResourceName;
            }

            if (this.ConnectionString.IsNullOrEmpty())
            {
                this.ConnectionString = this.BaseUri;
            }
            if (this.ConnectionString.IsNullOrEmpty()) { 
                this.ConnectionString =
                    $"{ResourceName}.redis.cache.windows.net:6380,ssl=True,abortConnect=False";
            }
            //For good measure:
            if (this.BaseUri.IsNullOrEmpty())
            {
                this.BaseUri = this.ConnectionString;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:App.Modules.All.Shared.Models.IHasEnabled" /> is enabled.
        /// <para>
        /// See <see cref="T:App.Modules.All.Shared.Models.IHasEnabledBeginningUtcDateTime" />
        /// and <see cref="T:App.Modules.All.Shared.Models.IHasEnabledEndUtcDateTime" /></para>
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// Gets or sets the base URI.
        /// <para>
        /// For http based services, will start with the protocol,
        /// other protocols (SMTP, Redis, etc.) might not
        /// (eg: SMTP MTA's it might look like 'smtp.gmail.com')
        /// </para>
        /// </summary>
        /// <value>
        /// The base URI (depending on the service type, with or without the protocol).
        /// </value>
        public string BaseUri { get; set; }


        /// <summary>
        /// Gets or sets the name of the resource.
        /// </summary>
        /// <value>
        /// The name of the resource.
        /// </value>
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the connection string.
        /// <para>
        /// <see cref="ClientSecret"/> will be appended to it
        /// as the password.
        /// </para>
        /// </summary>
        public string ConnectionString { get; set; }

        public string ClientIdentifier { get; set; }

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
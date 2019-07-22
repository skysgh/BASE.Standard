// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.All.Infrastructure.Configuration
{

    /// <summary>
    /// Abstract base class for <see cref="ConfigurationObjectBase"/>s
    /// that reference remote services (SMTP, Redis, etc.)
    /// </summary>
    /// <seealso cref="ConfigurationObjectBase" />
    /// <seealso cref="IHasServiceClientInformation" />
    public abstract class ServiceClientConfigurationObjectBase :
        ConfigurationObjectBase
        , IHasServiceClientInformation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceClientConfigurationObjectBase"/> class.
        /// </summary>
        protected ServiceClientConfigurationObjectBase()
        {
            Enabled = true;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceClientConfigurationObjectBase"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="configurationService">The configuration service.</param>
        protected ServiceClientConfigurationObjectBase(
            IDiagnosticsTracingService diagnosticsTracingService,
            IConfigurationService configurationService)
        {

            Enabled = true;
            Timeout = 30;

            configurationService.Get(this);
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
        /// Gets or sets the service's client account identifier.
        /// <para>
        /// That would be the SMTP service account name,
        /// the account name for a 3rd party malware service, etc.
        /// </para>
        /// </summary>
        public string ClientIdentifier { get; set; }
        /// <summary>
        /// Gets or sets the client secret/key
        /// used by this system to authenticate and authorise
        /// access to the remote service
        /// (ie, the secret key unique to
        /// the <see cref="T:App.Modules.All.Shared.Models.IHasServiceClientIdentifier" />.
        /// <para>
        /// Note the difference with
        /// <see cref="T:App.Modules.All.Shared.Models.IHasKey" /> which is used to define
        /// which attribute of an object is used as the
        /// primary index key (and is not necessarily
        /// the same as it's <see cref="T:App.Modules.All.Shared.Models.IHasName" />)
        /// </para>
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets any misc configuration (generally as a JSON string)
        /// (depends on service).
        /// </summary>
        public string MiscConfig { get; set; }


        /// <summary>
        /// Gets or sets the acceptable timeout (in seconds)
        /// before the connection is deemed as failure.
        /// </summary>
        public int Timeout { get; set; }
    }
}
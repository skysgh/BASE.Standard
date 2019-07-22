// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Models;

namespace App.Modules.All.Infrastructure.Configuration
{
    public abstract class AzureServiceClientConfigurationObjectBase :
        ConfigurationObjectBase,
        IHasEnabled,
        IHasBaseUri,
        IHasAzureResourceName
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureServuceClientConfigurationObjectBase" /> class.
        /// </summary>
        protected AzureServiceClientConfigurationObjectBase()
        {
            Enabled = false;
            Timeout = 30;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:App.Modules.All.Shared.Models.IHasEnabled" /> is enabled.
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

        public string ResourceName { get; set; }

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
        /// Gets or sets the acceptable timeout(in seconds)
        /// before the connection is deemed as failure.
        /// </summary>
        public int Timeout { get; set; }
    }
}
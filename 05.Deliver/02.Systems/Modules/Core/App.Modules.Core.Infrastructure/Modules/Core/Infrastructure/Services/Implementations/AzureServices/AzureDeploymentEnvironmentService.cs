// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Configuration.Settings;

namespace App.Modules.Core.Infrastructure.Services.Implementations.AzureServices
{
    public class AzureDeploymentEnvironmentService : AppCoreServiceBase, IAzureDeploymentEnvironmentService
    {
        private readonly Guid _tenantId = Guid.Empty;
        private readonly AzureEnvironmentSettings _configuration;
        private Guid _subscriptionId = Guid.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureDeploymentEnvironmentService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public AzureDeploymentEnvironmentService(
            AzureEnvironmentSettings configuration)
        {
            this._configuration = configuration;

            Guid.TryParse(configuration.SubscriptionId, out _subscriptionId);
            Guid.TryParse(configuration.TenantId, out _tenantId);
        }

        public string DefaultKeyVaultResourceName =>
            _configuration.DefaultKeyVaultResourceName;

        /// <summary>
        /// The Key to the Subscription within which
        /// this system was deployed to.
        /// </summary>
        public Guid SubscriptionId => _subscriptionId;

        /// <summary>
        /// Gets the tenant identifier.
        /// </summary>
        /// <value>
        /// The tenant identifier.
        /// </value>
        public Guid TenantId => _tenantId;

        /// <summary>
        ///     The name of the ResourceString to which thi
        /// </summary>
        public string ResourceGroupName => _configuration.ResourceGroupName;

        /// <summary>
        ///     The name of the ResourceString to which thi
        /// </summary>
        public string ResourceGroupLocation => _configuration.ResourceGroupName;

        /// <summary>
        /// Gets the default name of resources within the ResourceGroup.
        /// </summary>
        public string DefaultResourceName => _configuration.DefaultResourceName;
    }
}
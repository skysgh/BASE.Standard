// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Configuration.Services;
using App.Modules.Core.Infrastructure.Configuration.Settings;

namespace App.Modules.Core.Infrastructure.Services.Implementations.AzureServices
{
    public class AzureDeploymentEnvironmentService : AppCoreServiceBase, IAzureDeploymentEnvironmentService
    {
        private readonly AzureEnvironmentSettings _settings;
        private readonly Guid _tenantId = Guid.Empty;
        private Guid _subscriptionId = Guid.Empty;

        public AzureDeploymentEnvironmentService(
            AzureDeploymentEnvironmentServiceConfiguration azureDeploymentEnvironmentServiceConfiguration)
        {
            _settings = azureDeploymentEnvironmentServiceConfiguration.Settings;

            Guid.TryParse(_settings.SubscriptionId, out _subscriptionId);
            Guid.TryParse(_settings.TenantId, out _tenantId);
        }

        /// <summary>
        ///     The Key to the Subscription within which
        ///     this system was deployed to.
        /// </summary>
        public Guid SubscriptionId => SubscriptionId;

        public Guid TenantId => _tenantId;

        /// <summary>
        ///     The name of the ResourceString to which thi
        /// </summary>
        public string ResourceGroupName => _settings.ResourceGroupName;

        /// <summary>
        ///     The name of the ResourceString to which thi
        /// </summary>
        public string ResourceGroupLocation => _settings.ResourceGroupName;
    }
}
// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for a service to retrieve information about
    ///     the current deployment environment
    /// (retrieved using <see cref="AzureEnvironmentSettings"/>
    /// </summary>
    public interface IAzureDeploymentEnvironmentService 
        : IInfrastructureService
            , IAzureService
    {
        /// <summary>
        /// The Key to the Subscription within which
        /// this system was deployed to.
        /// </summary>
        /// <value>
        /// The subscription identifier.
        /// </value>
        Guid SubscriptionId { get; }

        /// <summary>
        /// Gets the identifier of the AAD
        /// Tenancy this system's sys account is
        /// managed by.
        /// </summary>
        Guid TenantId { get; }

        /// <summary>
        ///     The name of the ResourceString to which this
        /// system is deployed.
        /// </summary>
        string ResourceGroupName { get; }

        /// <summary>
        /// Gets the location of the resource group
        /// and therefore default location for resources
        /// within the group (although resources are not
        /// automatically in this location).
        /// </summary>
        string ResourceGroupLocation { get; }

        /// <summary>
        /// Gets the default name for resources within
        /// the <see cref="ResourceGroupName"/>
        /// where this system is deployed.
        /// </summary>
        string DefaultResourceName { get; }
    }
}
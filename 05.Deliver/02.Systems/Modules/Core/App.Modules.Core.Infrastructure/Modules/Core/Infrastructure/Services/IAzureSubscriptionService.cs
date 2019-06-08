using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{

    /// <summary>
    /// Contract for a service to retrieve information about 
    /// the current deployment environment.
    /// </summary>
    public interface IAzureDeploymentEnvironmentService : IInfrastructureService, IAzureService
    {

        /// <summary>
        /// The Key to the Subscription within which 
        /// this system was deployed to.
        /// </summary>
        Guid SubscriptionId { get;  }

        Guid TenantId { get;  }

        /// <summary>
        /// The name of the ResourceString to which thi
        /// </summary>
        string ResourceGroupName { get;  }

        string ResourceGroupLocation { get; }
    }
}

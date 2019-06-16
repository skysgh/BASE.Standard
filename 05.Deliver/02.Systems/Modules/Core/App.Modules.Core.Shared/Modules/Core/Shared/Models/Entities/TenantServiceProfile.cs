using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{



    /// <summary>
    /// The Service Profile (ie Subscription)
    /// to which a <c>Plan</c> plan is associated.
    /// <para>
    /// We are not associating a <see cref="ServicePlanDefinition"/> 
    /// to a <see cref="Principal"/> directly
    /// to the 
    /// </para>
    /// </summary>
    public class TenantServiceProfile : TenantFKRecordStatedTimestampedGuidIdEntityBase {


        // Not needed: Already part of the base class:
        ////public virtual Guid TenantFK { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Tenant"/>
        /// which this entity is associated to.
        /// </summary>
        public virtual Tenant Tenant { get; set; }


        /// <summary>
        /// A <see cref="TenantServiceProfile"/> most often 
        /// will be signed up to one <see cref="ServicePlanDefinition"/>.
        /// <para>
        /// But there are cases where the Tenancy is signed 
        /// up to multiple.
        /// </para>
        /// </summary>
        public virtual ICollection<TenantServiceProfileServicePlanAllocation> ServicePlans { 
            get { return _servicePlans ?? (_servicePlans = new Collection<TenantServiceProfileServicePlanAllocation>()); }
        }
        ICollection<TenantServiceProfileServicePlanAllocation> _servicePlans;


        /// <summary>
        /// The collection of direct Service Allocations.
        /// <para>
        /// Consider this as overrides of the default list of services 
        /// defined within the <see cref="ServicePlanDefinition"/>
        /// associated to this <see cref="TenantServiceProfile"/>.
        /// </para>
        /// </summary>
        public virtual ICollection<TenantServiceProfileServiceOfferingAllocation> Services {
            get { return _services ?? (_services = new Collection<TenantServiceProfileServiceOfferingAllocation>()); } }
        ICollection<TenantServiceProfileServiceOfferingAllocation> _services;

    }

}

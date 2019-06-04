﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App.Modules.Core.Models.Entities
{



    /// <summary>
    /// The Service Profile (ie Subscription)
    /// to which a <see cref="Plan"/> plan is associated.
    /// <para>
    /// We are not associating a <see cref="ServicePlan"/> 
    /// to a <see cref="Principal"/> directly
    /// to the 
    /// </para>
    /// </summary>
    public class PrincipalServiceProfile : TenantFKRecordStatedTimestampedGuidIdEntityBase {


        // Not needed: Already part of the base class:
        ////public virtual Guid TenantFK { get; set; }

        public virtual Entities.Tenant Tenant { get; set; }


        /// <summary>
        /// A <see cref="PrincipalServiceProfile"/> most often 
        /// will be signed up to one <see cref="ServiceProfile"/>.
        /// <para>
        /// But there are cases where the Tenancy is signed 
        /// up to multiple.
        /// </para>
        /// </summary>
        public virtual ICollection<PrincipalServiceProfileServicePlanAllocation> ServicePlans { 
            get { return _servicePlans ?? (_servicePlans = new Collection<PrincipalServiceProfileServicePlanAllocation>()); }
        }
        ICollection<PrincipalServiceProfileServicePlanAllocation> _servicePlans;


        /// <summary>
        /// The collection of direct Service Allocations.
        /// <para>
        /// Consider this as overrides of the default list of services 
        /// defined within the <see cref="ServicePlanDefinition"/>
        /// associated to this <see cref="PrincipalServiceProfile"/>.
        /// </para>
        /// </summary>
        public virtual ICollection<PrincipalServiceProfileServiceOfferingAllocation> Services {
            get { return _services ?? (_services = new Collection<PrincipalServiceProfileServiceOfferingAllocation>()); } }
        ICollection<PrincipalServiceProfileServiceOfferingAllocation> _services;

    }

}

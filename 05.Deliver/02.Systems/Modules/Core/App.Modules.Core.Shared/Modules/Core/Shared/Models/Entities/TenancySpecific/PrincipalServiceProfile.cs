// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     The Service Profile (ie Subscription)
    ///     to which a ServicePlan is associated.
    ///     <para>
    ///         We are not associating a ServicePlan
    ///         to a <see cref="Principal" /> directly
    ///         to the
    ///     </para>
    /// </summary>
    public class PrincipalServiceProfile : TenantFKRecordStatedTimestampedGuidIdEntityBase
    {
        private ICollection<PrincipalServiceProfileServicePlanAllocation> _servicePlans;
        private ICollection<PrincipalServiceProfileServiceOfferingAllocation> _services;


        // Not needed: Already part of the base class:
        ////public virtual Guid TenantFK { get; set; }

        /// <summary>
        ///     Gets or sets the tenant.
        /// </summary>
        /// <value>
        ///     The tenant.
        /// </value>
        public virtual Tenant Tenant { get; set; }


        /// <summary>
        ///     A <see cref="PrincipalServiceProfile" /> most often
        ///     will be signed up to one ServiceProfile.
        ///     <para>
        ///         But there are cases where the Tenancy is signed
        ///         up to multiple.
        ///     </para>
        /// </summary>
        public virtual ICollection<PrincipalServiceProfileServicePlanAllocation> ServicePlans =>
            _servicePlans ?? (_servicePlans = new Collection<PrincipalServiceProfileServicePlanAllocation>());


        /// <summary>
        ///     The collection of direct Service Allocations.
        ///     <para>
        ///         Consider this as overrides of the default list of services
        ///         defined within the <see cref="ServicePlanDefinition" />
        ///         associated to this <see cref="PrincipalServiceProfile" />.
        ///     </para>
        /// </summary>
        public virtual ICollection<PrincipalServiceProfileServiceOfferingAllocation> Services =>
            _services ?? (_services = new Collection<PrincipalServiceProfileServiceOfferingAllocation>());
    }
}
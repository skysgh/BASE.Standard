// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     The Complex Joint Object used to Assign ServiceOfferings to a TenantServiceIdentity, directly,
    ///     without going through a <see cref="TenantServiceProfile" />.
    ///     <para>
    ///         There's always an exception to any Plan
    ///         (beta, teaser, freebie to cover a stuffup, etc.)
    ///     </para>
    /// </summary>
    public class TenantServiceProfileServiceOfferingAllocation : UntenantedRecordStatedTimestampedGuidIdEntityBase
    {
        /// <summary>
        ///     The Type of assignment, defining whether
        ///     the Service is being added, or removed (ie
        ///     maybe it's already part of a <see cref="ServicePlanDefinition" />
        ///     but it's being removed in this case, for some reason).
        /// </summary>
        public AssignmentType Type { get; set; }


        /// <summary>
        ///     Price/Month
        ///     <para>
        ///         This billing only comes into effect if the
        ///         Service is associated directly to a
        ///         <see cref="TenantServiceProfile" />
        ///     </para>
        /// </summary>
        public virtual decimal CostPerMonth { get; set; }

        /// <summary>
        ///     Price/Year if a year is signed up for.
        ///     <para>
        ///         This billing only comes into effect if the
        ///         Service is associated directly to a
        ///         <see cref="TenantServiceProfile" />
        ///     </para>
        /// </summary>
        public virtual decimal CostPerYear { get; set; }


        /// <summary>
        ///     The FK of the
        ///     parent
        ///     <see cref="TenantServiceProfile" />
        /// </summary>
        public Guid ServiceProfileFK { get; set; }
        //public TenantServiceProfile ServiceProfile {get;set;}


        /// <summary>
        ///     The FK of the <see cref="ServiceOfferingDefinition" />
        ///     this <see cref="TenantServiceProfileServiceOfferingAllocation" />
        ///     is allocating to the <see cref="TenantServiceProfile" />
        /// </summary>
        public Guid ServiceOfferingFK { get; set; }


        /// <summary>
        ///     The <see cref="ServiceOfferingDefinition" />
        ///     this <see cref="TenantServiceProfileServiceOfferingAllocation" />
        ///     is allocating to the <see cref="TenantServiceProfile" />
        /// </summary>
        public ServiceOfferingDefinition ServiceOffering { get; set; }
    }
}
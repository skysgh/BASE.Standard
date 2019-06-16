﻿using System;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// The Complex Joint Object used to Assign ServiceOfferings to a TenantServiceIdentity, directly, 
    /// without going through a <see cref="ServicePlanDefinition"/>.
    /// <para>
    /// There's always an exception to any Plan 
    /// (beta, teaser, freebie to cover a stuffup, etc.)
    /// </para>
    /// </summary>
    public class PrincipalServiceProfileServiceOfferingAllocation : UntenantedRecordStatedTimestampedGuidIdEntityBase
    {

        /// <summary>
        /// The Type of assignment, defining whether
        /// the Service is being added, or removed (ie
        /// maybe it's already part of a <see cref="ServicePlanDefinition"/>
        /// but it's being removed in this case, for some reason).
        /// </summary>
        public AssignmentType Type { get; set; }

        /// <summary>
        /// Price/Month
        /// <para>
        /// This billing only comes into effect if the
        /// Service is associated directly to a 
        /// <see cref="PrincipalServiceProfile"/>
        /// </para>
        /// </summary>
        public virtual decimal CostPerMonth { get; set; }

        /// <summary>
        /// Price/Year if a year is signed up for.
        /// <para>
        /// This billing only comes into effect if the
        /// Service is associated directly to a 
        /// <see cref="PrincipalServiceProfile"/>
        /// </para>
        /// </summary>
        public virtual decimal CostPerYear { get; set; }


        /// <summary>
        /// The FK of the <see cref="PrincipalServiceProfile"/>
        /// this <see cref="PrincipalServiceProfileServiceOfferingAllocation"/>
        /// belongs to.
        /// </summary>
        public Guid ServiceProfileFK { get; set; }
        //public TenantServiceProfile ServiceProfile {get;set;}

        /// <summary>
        /// The FK of the <see cref="ServiceOfferingDefinition"/>
        /// this <see cref="PrincipalServiceProfileServiceOfferingAllocation"/>
        /// is allocating to the owning
        /// <see cref="PrincipalServiceProfile"/>
        /// </summary>
        public Guid ServiceOfferingFK { get; set; }
        /// <summary>
        /// Gets or sets the service offering.
        /// </summary>
        public ServiceOfferingDefinition ServiceOffering { get; set; }

    }

}

// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     A Join object between a <see cref="ServicePlanDefinition" />
    ///     and <see cref="ServiceDefinition" />.
    /// </summary>
    public class ServiceOfferingDefinition : UntenantedRecordStatedTimestampedGuidIdReferenceDataEntityBase, IHasKey
    {
        /// <summary>
        ///     The FK of the child <see cref="ServiceDefinition" />
        /// </summary>
        public virtual Guid ServiceFK { get; set; }

        /// <summary>
        ///     The child <see cref="ServiceDefinition" />
        /// </summary>
        public virtual ServiceDefinition Service { get; set; }

        /// <summary>
        ///     TODO: Gets or sets the principal limit.
        /// </summary>
        /// <value>
        ///     The principal limit.
        /// </value>
        public int PrincipalLimit { get; set; }

        /// <summary>
        ///     TODO: Gets or sets the resource limit.
        /// </summary>
        /// <value>
        ///     The resource limit.
        /// </value>
        public int ResourceLimit { get; set; }

        /// <summary>
        ///     TODO: Price/Month
        ///     <para>
        ///         This billing only comes into effect if the
        ///         Service is associated directly to a
        ///         <see cref="TenantServiceProfile" />
        ///     </para>
        ///     <para>
        ///         Used to set the CostPerMonth within a
        ///         <see cref="TenantServiceProfileServiceOfferingAllocation" />,
        ///         which can be overridden as needed by other logic (freebie, etc).
        ///     </para>
        /// </summary>
        public virtual decimal DefaultCostPerMonth { get; set; }

        /// <summary>
        ///     Price/Year if a year is signed up for.
        ///     <para>
        ///         This billing only comes into effect if the
        ///         Service is associated directly to a
        ///         <see cref="TenantServiceProfile" />
        ///     </para>
        ///     <para>
        ///         Used to set the CostPerMonth within a
        ///         <see cref="TenantServiceProfileServiceOfferingAllocation" />,
        ///         which can be overridden as needed by other logic (freebie, etc).
        ///     </para>
        /// </summary>
        public virtual decimal DefaultCostPerYear { get; set; }

        /// <summary>
        ///     The (indexed) unique Key for this Offering
        /// </summary>
        public virtual string Key { get; set; }

        ///// <summary>
        ///// The collection of optional limits (users, resources, etc).
        ///// <para>
        ///// An example limit would be when a 
        ///// "Basic" ServicePlanDefinition allows for 5 Users, and
        ///// only the creation of 1 of this type of Resource.
        ///// </para>
        ///// </summary>
        //public ICollection<ServiceOfferingDefinitionLimit> Limits {
        //    get { return _limits ?? (_limits = new Collection<ServiceOfferingDefinitionLimit>()); }
        //}
        //ICollection<ServiceOfferingDefinitionLimit> _limits;
    }
}
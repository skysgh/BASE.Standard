// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities.TenantMember.Profile
{
    /// <summary>
    ///     The profile of a Principal within a Tenancy.
    /// </summary>
    public class TenantMemberProfile
        : TenantFKRecordStatedTimestampedGuidIdEntityBase,
            IHasEnabled,
            IHasEnabledBeginningUtcDateTime,
            IHasEnabledEndUtcDateTime
    {
        private ICollection<TenantMemberProfileClaim> _claims;
        private ICollection<TenantMemberProfileProperty> _properties;
        private ICollection<TenantMemberProfile2TagAssignment> _tagAssignments;

        /// <summary>
        ///     Gets or sets the display name.
        /// </summary>
        /// <value>
        ///     The display name.
        /// </value>
        public virtual string DisplayName { get; set; }

        /// <summary>
        ///     Gets or sets the FK of the
        ///     <see cref="DataClassification" />.
        /// </summary>
        public virtual NZDataClassification? DataClassificationFK { get; set; }

        /// <summary>
        ///     Gets or sets the
        ///     <see cref="DataClassification" />.
        /// </summary>
        public virtual DataClassification DataClassification { get; set; }

        /// <summary>
        ///     Gets or sets the FK of the
        ///     <see cref="TenantMemberProfileCategory" />.
        /// </summary>
        public virtual Guid CategoryFK { get; set; }

        /// <summary>
        ///     Gets or sets the FK of the
        ///     <see cref="TenantMemberProfileCategory" />.
        /// </summary>
        public virtual TenantMemberProfileCategory Category { get; set; }


        /// <summary>
        ///     Gets or sets the FK of the
        ///     <see cref="TenantSecurityProfile" />.
        /// </summary>
        public virtual Guid SecurityProfileFK { get; set; }

        /// <summary>
        ///     Gets or sets the FK of the
        ///     <see cref="TenantSecurityProfile" />.
        /// </summary>
        public virtual TenantSecurityProfile SecurityProfile { get; set; }


        /// <summary>
        ///     The collection of optional Properties associated to the tenant member.
        /// </summary>
        public virtual ICollection<TenantMemberProfileProperty> Properties
        {
            get
            {
                if (_properties == null)
                {
                    _properties = new Collection<TenantMemberProfileProperty>();
                }

                return _properties;
            }
            set => _properties = value;
        }

        /// <summary>
        ///     The collection of optional Claims associated to the tenant member.
        /// </summary>
        public virtual ICollection<TenantMemberProfileClaim> Claims
        {
            get
            {
                if (_claims == null)
                {
                    _claims = new Collection<TenantMemberProfileClaim>();
                }

                return _claims;
            }
            set => _claims = value;
        }


        /// <summary>
        ///     The collection of optional Tags associated to the end user.
        /// </summary>
        public virtual ICollection<TenantMemberProfile2TagAssignment> TagAssignments
        {
            get
            {
                if (_tagAssignments == null)
                {
                    _tagAssignments = new Collection<TenantMemberProfile2TagAssignment>();
                }

                return _tagAssignments;
            }
            set => _tagAssignments = value;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="T:App.Modules.All.Shared.Models.IHasEnabled" /> is enabled.
        ///     <para>
        ///         See <see cref="T:App.Modules.All.Shared.Models.IHasEnabledBeginningUtcDateTime" />
        ///         and <see cref="T:App.Modules.All.Shared.Models.IHasEnabledEndUtcDateTime" />
        ///     </para>
        /// </summary>
        public virtual bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets when the the record will be disabled.
        /// </summary>
        public DateTimeOffset? EnabledBeginningUtcDateTime { get; set; }

        /// <summary>
        ///     Gets or sets the future UTC date time
        ///     when the object will be disabled.
        ///     <para>
        ///         <see cref="T:App.Modules.All.Shared.Models.IHasEnabled" />
        ///     </para>
        /// </summary>
        public DateTimeOffset? EnabledEndingUtcDateTime { get; set; }
    }
}
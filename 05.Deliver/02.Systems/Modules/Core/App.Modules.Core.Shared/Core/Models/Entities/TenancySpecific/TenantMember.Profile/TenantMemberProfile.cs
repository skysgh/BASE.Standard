using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App.Modules.Core.Models.Entities.TenantMember.Profile
{
    /// <summary>
    /// The profile of a Principal within a Tenancy.
    /// </summary>
    public class TenantMemberProfile : TenantFKRecordStatedTimestampedGuidIdEntityBase, IHasEnabled, IHasEnabledBeginningUtc, IHasEndDateUtc {

        public DateTime? EnabledBeginningUtc { get; set; }
        public DateTime? EnabledEndingUtc { get; set; }
        public virtual bool Enabled { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual NZDataClassification? DataClassificationFK { get; set; }
        public virtual DataClassification DataClassification { get; set; }

        public virtual TenantMemberProfileCategory Category { get; set; }
        public virtual Guid CategoryFK { get; set; }

        public virtual TenantSecurityProfile SecurityProfile { get; set; }
        public virtual Guid SecurityProfileFK { get; set; }





        /// <summary>
        /// The collection of optional Properties associated to the tenant member.
        /// </summary>
        public virtual ICollection<TenantMemberProfileProperty> Properties
        {
            get
            {
                if (this._properties == null)
                {
                    this._properties = new Collection<TenantMemberProfileProperty>();
                }
                return this._properties;
            }
            set => this._properties = value;
        }
        private ICollection<TenantMemberProfileProperty> _properties;

        /// <summary>
        /// The collection of optional Claims associated to the tenant member.
        /// </summary>
        public virtual ICollection<TenantMemberProfileClaim> Claims
        {
            get
            {
                if (this._claims == null)
                {
                    this._claims = new Collection<TenantMemberProfileClaim>();
                }
                return this._claims;
            }
            set => this._claims = value;
        }
        private ICollection<TenantMemberProfileClaim> _claims;


        /// <summary>
        /// The collection of optional Tags associated to the end user.
        /// </summary>
        public virtual ICollection<TenantMemberProfile2TagAssignment> TagAssignments
        {
            get
            {
                if (this._tagAssignments == null)
                {
                    this._tagAssignments = new Collection<TenantMemberProfile2TagAssignment>();
                }
                return this._tagAssignments;
            }
            set => this._tagAssignments = value;
        }
        private ICollection<TenantMemberProfile2TagAssignment> _tagAssignments;



    }
}
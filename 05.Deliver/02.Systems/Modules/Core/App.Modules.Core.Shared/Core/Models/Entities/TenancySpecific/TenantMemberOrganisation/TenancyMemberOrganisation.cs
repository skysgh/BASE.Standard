using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App.Modules.Core.Models.Entities.TenantMemberOrganisation
{
    /// <summary>
    /// A Group of Members of an Organisation
    /// </summary>
    /// 
    public class TenancyMemberOrganisation : TenantFKRecordStatedTimestampedGuidIdEntityBase, IHasTitleAndDescription
    {

        /// <summary>
        /// The Title of the Group of Members
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Description of the Group of Members.
        /// </summary>
        public string Description { get; set; }



        public ICollection<TenancyMemberOrganisation2MemberAssignment> GroupRoleAssignments
        {
            get
            {
                return _tenantMemberOrganisationRoleAssignments ?? (_tenantMemberOrganisationRoleAssignments = new Collection<TenancyMemberOrganisation2MemberAssignment>());
            }
            set
            {
                _tenantMemberOrganisationRoleAssignments = value;
            }
        }
        private ICollection<TenancyMemberOrganisation2MemberAssignment> _tenantMemberOrganisationRoleAssignments;

        //TODO: Could get large. Do we want this? Maybe it should only be on Account.
        //public ICollection<Account> Accounts { get; set; } 

    }
}

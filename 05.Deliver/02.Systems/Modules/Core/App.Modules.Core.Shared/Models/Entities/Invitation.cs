using System;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// An invitation to a member.
    /// </summary>
    public class Invitation : UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase, IHasEnabledBeginningUtc, IHasEndDateUtc
    {
        /// <summary>
        /// Date the invitation was sent out.
        /// </summary>
        public DateTime? EnabledBeginningUtc { get; set; }


        /// <summary>
        /// Date the invitation expires.
        /// </summary>
        public DateTime? EnabledEndingUtc { get; set; }


        public TenancyMemberOrganisationInvitationState State { get; set; }

        /// <summary>
        /// <para>
        /// A User may not yet be a member of an Organisation or even a Tenancy.
        /// So you can't refer to an FK.
        /// But email addresses are problematic to search on (case sensitivity, including the user name in quotations, etc.)
        /// </para>
        /// </summary>
        public string PrincipalEmail { get; set; }


        /// <summary>
        /// The organisation the Principal is being invited to.
        /// </summary>
        public Guid TenancyMemberOrganisationFK { get; set; }


        /// <summary>
        /// The role in which the Member is being invited as:
        /// </summary>
        public TenancyMemberOrganisationRole Role { get; set; }


    }
}

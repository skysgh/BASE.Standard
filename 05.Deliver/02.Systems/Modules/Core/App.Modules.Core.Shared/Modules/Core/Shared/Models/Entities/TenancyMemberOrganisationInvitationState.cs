// Copyright MachineBrains, Inc. 2019

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     Enumeration of states an invitation can be in.
    /// </summary>
    public enum TenancyMemberOrganisationInvitationState
    {
        /// <summary>
        ///     The inviitation is still pending
        /// </summary>
        Pending,

        /// <summary>
        ///     The invitation was declined
        /// </summary>
        Declined,

        /// <summary>
        ///     The invitation was accepted
        /// </summary>
        ResponsibilitiesAccepted
    }
}
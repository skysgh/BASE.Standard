// Copyright MachineBrains, Inc.
namespace App.Modules.Core.Shared.Models.Entities
{
    public enum TenancyMemberOrganisationRole
    {
        /// <summary>
        /// User is an Owner of the Organisation.
        /// </summary>
        Owner,
        /// <summary>
        /// User is authorised to manage the organisation.
        /// </summary>
        Admin,
        /// <summary>
        /// User is an authorised contact person for the Organisation.
        /// </summary>
        ContactPerson,
        /// <summary>
        /// User is a member of the Member organisation.
        /// </summary>
        Member
    }
}
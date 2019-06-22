﻿// Copyright MachineBrains, Inc. 2019

namespace App.Modules.Core.Shared.Models.Entities.TenantMemberOrganisation
{
    /// <summary>
    ///     TODO
    /// </summary>
    public enum TenancyMemberOrganisationRole
    {
        /// <summary>
        ///     User is an Owner of the Organisation.
        /// </summary>
        Owner,

        /// <summary>
        ///     User is authorised to manage the organisation.
        /// </summary>
        Admin,

        /// <summary>
        ///     User is an authorised contact person for the Organisation.
        /// </summary>
        ContactPerson,

        /// <summary>
        ///     User is a member of the Member organisation.
        /// </summary>
        Member
    }
}
﻿// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     A Principal can login from several foreign IdPs (FB, Google, ML, thisApp...).
    ///     The user will be known by the remote Idp under a different login (eg: foo@google.com)
    ///     as well as a unique reference id for the user (often a guid, but can be anything, hence string storage is best).
    ///     When an IdP sends back the response, it has to be correlated back to a System Principal.
    ///     That's done via this object.
    /// </summary>
    public class PrincipalLogin
        : UntenantedRecordStatedTimestampedGuidIdEntityBase
            , IHasEnabled
            , IHasOwnerFK
            , IHasPrincipalFK
    {
        /// <summary>
        ///     The Credential Name/Login the external IdP uses to distinguish users by (eg: google.com, sts, etc.).
        /// </summary>
        public string IdPLogin { get; set; }

        /// <summary>
        ///     The Subject Identifier the external IdP uses to distinguish users by (eg: 'some guid, joeblow',
        ///     'joeblow@google.com', etc.).
        /// </summary>
        public string SubLogin { get; set; }

        /// <summary>
        ///     Last datetime the user signed in via this login.
        /// </summary>
        public DateTimeOffset LastLoggedInUtc { get; set; }

        /// <summary>
        ///     Can be used to disallow an external IdP login that was previsoulsy trusted.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        ///     Returns the FK of the
        ///     parent, owning entity.
        /// </summary>
        /// <returns></returns>
        public Guid GetOwnerFk()
        {
            return PrincipalFK;
        }

        /// <summary>
        ///     Gets or sets the FK of the Principal.
        ///     <para>
        ///         Note that as as the property name
        ///         ends with FK (and not Id)
        ///         it is Db enforced, and not just a weak
        ///         reference.
        ///     </para>
        /// </summary>
        public Guid PrincipalFK { get; set; }
    }
}
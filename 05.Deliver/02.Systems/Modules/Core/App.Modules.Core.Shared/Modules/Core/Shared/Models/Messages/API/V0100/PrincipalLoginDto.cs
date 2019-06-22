// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    ///     DTO for <see cref="PrincipalLogin" />
    ///     entities
    /// </summary>
    public class PrincipalLoginDto
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the principal fk.
        /// </summary>
        public Guid PrincipalFK { get; set; }

        /// <summary>
        ///     Can be used to disallow an external IdP login that was previously trusted.
        /// </summary>
        public bool Enabled { get; set; }

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
    }
}
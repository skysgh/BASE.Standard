// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{


    /// <summary>
    ///     Background:
    ///     As per https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration
    /// </summary>
    public class PrincipalTagAssignment : UntenantedRecordStatedTimestampedNoIdEntityBase,
        IHasPrincipal
    {
        /// <summary>
        ///     Gets or sets the FK of the PrincipalTag
        /// </summary>
        /// <value>
        ///     The tag fk.
        /// </value>
        public Guid TagFK { get; set; }

        /// <summary>
        ///     Gets or sets the Tag
        ///     associated to the record.
        /// </summary>
        public PrincipalTag Tag { get; set; }

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

        /// <summary>
        ///     Gets or sets the principal.
        /// </summary>
        public Principal Principal { get; set; }
    }
}
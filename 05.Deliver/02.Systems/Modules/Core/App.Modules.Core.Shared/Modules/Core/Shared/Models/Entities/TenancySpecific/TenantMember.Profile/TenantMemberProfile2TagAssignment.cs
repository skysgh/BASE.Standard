// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities.TenantMember.Profile
{
    /// <summary>
    ///     TODO
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.TenantFKRecordStatedTimestampedNoIdEntityBase" />
    public class TenantMemberProfile2TagAssignment : TenantFKRecordStatedTimestampedNoIdEntityBase
    {
        /// <summary>
        ///     Gets or sets the fk
        ///     of the parent <see cref="TenantPrincipal" />
        /// </summary>
        /// <value>
        ///     The tenant principal fk.
        /// </value>
        public Guid TenantPrincipalFK { get; set; }

        /// <summary>
        ///     Gets or sets
        ///     the parent <see cref="TenantPrincipal" />
        /// </summary>
        public TenantMemberProfile TenantPrincipal { get; set; }

        /// <summary>
        ///     Gets or sets the fk
        ///     of the Tag
        /// </summary>
        /// <value>
        ///     The tag fk.
        /// </value>
        public Guid TagFK { get; set; }

        /// <summary>
        ///     Gets or sets the tag.
        /// </summary>
        public TenantMemberProfileTag Tag { get; set; }
    }
}
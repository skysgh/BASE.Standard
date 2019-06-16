using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities.TenantMember.Profile
{
    /// <summary>
    /// A trustable claim regarding the tenant member.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.TenantFKRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasRecordState" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasAuthoritySignature" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasOwnerFK" />
    public class TenantMemberProfileClaim 
        : TenantFKRecordStatedTimestampedGuidIdEntityBase
            , IHasRecordState
            , IHasAuthoritySignature
            , IHasOwnerFK
    {
        /// <summary>
        /// Gets or sets the authority backing the signature.
        /// </summary>
        public virtual string Authority { get; set; }
        /// <summary>
        /// Gets or sets the authority's digital signature
        /// of the protected attribute(s).
        /// </summary>
        public virtual string AuthoritySignature { get; set; }
        /// <summary>
        /// Gets or sets the object's unique key.
        /// </summary>
        public virtual string Key { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public virtual string Value { get; set; }

        /// <summary>
        /// Gets or sets the FK of the parent <see cref="TenantMemberProfile"/>.
        /// </summary>
        /// <value>
        /// The principal profile fk.
        /// </value>
        public virtual Guid PrincipalProfileFK { get; set; }
        //public virtual RecordPersistenceState RecordState { get; set; }


        /// <summary>
        /// Implementation of <see cref="IHasOwnerFK"/>
        /// <para>
        /// To get parent <see cref="TenantMemberProfile"/>
        /// </para>
        /// </summary>
        /// <returns></returns>
        public Guid GetOwnerFk()
        {
            return PrincipalProfileFK;
        }
    }
}
using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// A Claim that can be associated to a Principal
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.UntenantedRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasRecordState" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasOwnerFK" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasKeyValue{String}" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasPrincipalFK" />
    public class PrincipalClaim 
        : UntenantedRecordStatedTimestampedGuidIdEntityBase
            , IHasRecordState
            , IHasOwnerFK
            , IHasKeyValue<string>
    ,IHasPrincipalFK
    , IHasAuthoritySignature

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
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public virtual string Key { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public virtual string Value { get; set; }
        /// <summary>
        /// Gets or sets the FK of the Principal.
        /// <para>
        /// Note that as as the property name
        /// ends with FK (and not Id)
        /// it is Db enforced, and not just a weak
        /// reference.
        /// </para>
        /// </summary>
        public virtual Guid PrincipalFK { get; set; }
        //public virtual RecordPersistenceState RecordState { get; set; }


        /// <summary>
        /// Returns the FK of the
        /// parent, owning entity.
        /// </summary>
        /// <returns></returns>
        public Guid GetOwnerFk()
        {
            return PrincipalFK;
        }
    }
}
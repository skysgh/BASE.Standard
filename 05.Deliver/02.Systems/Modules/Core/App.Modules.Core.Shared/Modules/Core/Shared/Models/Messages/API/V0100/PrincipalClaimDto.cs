using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    /// DTO for <see cref="PrincipalClaim"/>
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasRecordState" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasPrincipalFK" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasKey" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasValue{String}" />
    public class PrincipalClaimDto 
        /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ 
        : IHasGuidId
            , IHasRecordState
            , IHasPrincipalFK
            , IHasKey
            , IHasValue<string>
    ,IHasAuthoritySignature

    {
        /// <summary>
        /// Gets or sets the authority key.
        /// </summary>
        /// <value>
        /// The authority key.
        /// </value>
        public virtual string Authority { get; set; }
        /// <summary>
        /// Gets or sets the signature.
        /// </summary>
        /// <value>
        /// The signature.
        /// </value>
        public virtual string AuthoritySignature { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public virtual Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the unique key of the object,
        /// by which it is indexed when persisted
        /// (in additional to any primary Id).
        /// <para>
        /// Not the same as <see cref="T:App.Modules.All.Shared.Models.IHasName" /></para>.
        /// </summary>
        public virtual string Key { get; set; }

        /// <summary>
        /// Gets or sets the FK of the
        /// <see cref="T:App.Modules.Core.Shared.Models.Entities.Principal" />
        /// </summary>
        /// <value>
        /// The principal fk.
        /// </value>
        public virtual Guid PrincipalFK { get; set; }
        /// <summary>
        /// Gets or sets the logical state of the record:
        /// </summary>
        /// <value>
        /// The state of the record.
        /// </value>
        public virtual RecordPersistenceState RecordState { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public virtual string Value { get; set; }
    }
}
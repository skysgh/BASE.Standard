using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// A Claim associated to a Tenant
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.UntenantedRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasOwnerFK" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasKey" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasValue{String}" />
    public class TenantClaim
            : UntenantedRecordStatedTimestampedGuidIdEntityBase
                , IHasOwnerFK
                , IHasKey
                ,IHasTenantFK
                ,IHasAuthoritySignature
    
                , IHasValue<string>
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        /// <summary>
        /// Gets or sets the authority.
        /// </summary>
        /// <value>
        /// The authority.
        /// </value>
        public virtual string Authority { get; set; }
        /// <summary>
        /// Gets or sets the authority signature.
        /// </summary>
        /// <value>
        /// The authority signature.
        /// </value>
        public virtual string AuthoritySignature { get; set; }
        /// <summary>
        /// Gets or sets the unique key of the object,
        /// by which it is indexed when persisted
        /// (in additional to any primary Id).
        /// <para>
        /// Not the same as <see cref="T:App.Modules.All.Shared.Models.IHasName" /></para>.
        /// </summary>
        public virtual string Key { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public virtual string Value { get; set; }
        /// <summary>
        /// Gets or sets the FK of the Tenancy this mutable model belongs to.
        /// <para>
        /// When referenced from within the Core Module's DbContext
        /// the TenantFK is logically enforced by the database (normalized),
        /// whereas from other DbContexts it is not.
        /// The Logic behind this choice stems from the understanding that
        /// a Business Model (eg: Foo) has no need to Navigate to a Tenant to which
        /// the Business Model belongs. It's actually a different Domain Context (System).
        /// The above logic is actually enforced in EF's natural constraint that a Model
        /// belong to only one DbContext (one Bounded Context).
        /// The advantage is natural Domain Separation. In the same way as we trust external
        /// IdP Services to manage Users.
        /// THe consideration is that Application logic is required to ensure TenantId
        /// is applied at the Application Logic tier, as it is not enforced at the database.
        /// TenantFK is not required on anything else but the TenantProperties entity, and Users
        /// in order to know which Tenant a user is allowed to be a member of.
        /// </para>
        /// </summary>
        /// <value>
        /// The tenant fk.
        /// </value>
        public virtual Guid TenantFK { get; set; }

        /// <summary>
        /// Returns the FK of the
        /// parent, owning entity.
        /// </summary>
        /// <returns></returns>
        public Guid GetOwnerFk()
        {
            return TenantFK;
        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
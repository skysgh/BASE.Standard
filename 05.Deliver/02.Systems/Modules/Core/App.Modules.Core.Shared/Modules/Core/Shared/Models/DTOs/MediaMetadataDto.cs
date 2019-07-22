// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.DTOs
{
    /// <summary>
    ///     DTO for <see cref="MediaMetadata" /> entities.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTenantFK" />
    public class MediaMetadataDto
        /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */
        : IHasGuidId,
            IHasTenantFK //, IHasRecordState
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MediaMetadataDto" /> class.
        /// </summary>
        public MediaMetadataDto()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public virtual Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the FK of the Tenancy this mutable model belongs to.
        ///     <para>
        ///         When referenced from within the Core Module's DbContext
        ///         the TenantFK is logically enforced by the database (normalized),
        ///         whereas from other DbContexts it is not.
        ///         The Logic behind this choice stems from the understanding that
        ///         a Business Model (eg: Foo) has no need to Navigate to a Tenant to which
        ///         the Business Model belongs. It's actually a different Domain Context (System).
        ///         The above logic is actually enforced in EF's natural constraint that a Model
        ///         belong to only one DbContext (one Bounded Context).
        ///         The advantage is natural Domain Separation. In the same way as we trust external
        ///         IdP Services to manage Users.
        ///         THe consideration is that Application logic is required to ensure TenantId
        ///         is applied at the Application Logic tier, as it is not enforced at the database.
        ///         TenantFK is not required on anything else but the TenantProperties entity, and Users
        ///         in order to know which Tenant a user is allowed to be a member of.
        ///     </para>
        /// </summary>
        /// <value>
        ///     The tenant fk.
        /// </value>
        public virtual Guid TenantFK { get; set; }


        // Use an Enum as DataClassification is shared across Bounded DbContexts
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public virtual DataClassification DataClassification { get; set; }
        public virtual DateTimeOffset UploadedDateTimeUtc { get; set; }
        public virtual long ContentSize { get; set; } /*size of stream*/
        public virtual string MimeType { get; set; } /*The extension is not always a correct indicator...*/
        public virtual string SourceFileName { get; set; } /*the name the file had on the uploader's machine*/
        public virtual string ContentHash { get; set; } /*unique hash of the stream for faster reference later*/

        public virtual string LocalName { get; set; } /*name in storage container*/

        // Results of scanning, whenever done:
        public virtual DateTimeOffset? LatestScanDateTimeUtc { get; set; } /*can be scanned regularly*/
        public virtual bool? LatestScanMalwareDetetected { get; set; }
        public virtual string LatestScanResults { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
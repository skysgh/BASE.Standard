using System;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// Local Membership info is kept separate from Principal
    /// as it has nothing to do with Principal or business.
    /// Can't repeat this enough. Use an external 3rd party IdP.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTimestamp" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasRecordState" />
    public class PrincipalMembershipInfo: IHasGuidId, IHasTimestamp, IHasRecordState
    {
        // If the info in your app is valuable to someone, 
        // it's never an issue of if. It's an issue of when.
        // So if you persist not using an IdP (AAD, B2C, whatever),
        // do *NOT* save user information in a non-encrypted state.
        // ie: Email and Phone info used for authentication purposes must be encrypted.

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the datastore concurrency check timestamp.
        /// <para>
        /// Note that this is filled in when persisted in the db --
        /// so it's usable to determine whether Record is New or not.
        /// </para>
        /// </summary>
        public byte[] Timestamp { get; set; }
        /// <summary>
        /// Gets or sets the logical state of the record:
        /// </summary>
        /// <value>
        /// The state of the record.
        /// </value>
        public RecordPersistenceState RecordState { get; set; }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public string EncryptedEmailAddress { get; set; }
        public string EmailConfirmed { get; set; }

        public bool TFAEnabled { get; set; }
        public string TFAEncryptedDeviceNumber { get; set; }
        public string TFADeviceConfirmed { get; set; }

        // Used to count incorrect attempts, and lock out the Principal
        public int IncorrectAttemptCount { get; set; }
        public DateTimeOffset? LockedOutUntillUtc { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        /* GOD I HATE DOING THIS WITHIN AN APP. USE AN IDP! */

    }
}

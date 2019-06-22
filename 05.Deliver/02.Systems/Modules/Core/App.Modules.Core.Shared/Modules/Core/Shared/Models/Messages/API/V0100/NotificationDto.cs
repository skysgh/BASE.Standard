// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    ///     DTO for <see cref="Notification" /> entities.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTenantFK" />
    public class NotificationDto
        /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */
        : IHasGuidId, IHasTenantFK,
            IHasTraceLevel
        //, IHasRecordState
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NotificationDto" /> class.
        /// </summary>
        public NotificationDto()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        public virtual NotificationType Type { get; set; }

        /// <summary>
        ///     Gets or sets from.
        /// </summary>
        /// <value>
        ///     From.
        /// </value>
        public virtual string From { get; set; }

        /// <summary>
        ///     Gets or sets the image URL.
        /// </summary>
        /// <value>
        ///     The image URL.
        /// </value>
        public virtual string ImageUrl { get; set; }

        /// <summary>
        ///     Gets or sets the rendering class.
        /// </summary>
        /// <value>
        ///     The class.
        /// </value>
        public virtual string Class { get; set; }

        /// <summary>
        ///     Gets or sets the date time created UTC.
        /// </summary>
        /// <value>
        ///     The date time created UTC.
        /// </value>
        public virtual DateTimeOffset DateTimeCreatedUtc { get; set; }

        /// <summary>
        ///     Gets or sets the date time read UTC.
        /// </summary>
        /// <value>
        ///     The date time read UTC.
        /// </value>
        public virtual DateTimeOffset? DateTimeReadUtc { get; set; }

        /// <summary>
        ///     Status whether Message has been read.
        /// </summary>
        public virtual bool IsRead
        {
            get => DateTimeReadUtc.HasValue;
            set
            {
                if (value == false)
                {
                    DateTimeReadUtc = null;
                }
                else
                {
                    if (!DateTimeReadUtc.HasValue)
                    {
                        DateTimeReadUtc = DateTimeOffset.UtcNow;
                    }
                }
            }
        }

        /// <summary>
        ///     1-100% complete.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        /// <value>
        ///     The text.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; }

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
        public Guid TenantFK { get; set; }

        /// <summary>
        ///     Gets or sets the level.
        /// </summary>
        /// <value>
        ///     The level.
        /// </value>
        public virtual TraceLevel Level { get; set; }
    }
}
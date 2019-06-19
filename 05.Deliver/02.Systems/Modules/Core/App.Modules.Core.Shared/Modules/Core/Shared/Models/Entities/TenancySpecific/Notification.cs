using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// Notification entity
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.TenantFKRecordStatedTimestampedGuidIdEntityBase" />
    public class Notification 
        : TenantFKRecordStatedTimestampedGuidIdEntityBase,
            IHasPrincipalFK,
            IHasValue<int>
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public virtual NotificationType Type { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public virtual TraceLevel Level { get; set; }

        /// <summary>
        /// Gets or sets the FK of the
        /// <see cref="T:App.Modules.Core.Shared.Models.Entities.Principal" />
        /// </summary>
        public virtual Guid PrincipalFK { get; set; }

        /// <summary>
        /// Gets or sets the date time created UTC.
        /// </summary>
        /// <value>
        /// The date time created UTC.
        /// </value>
        public virtual DateTimeOffset DateTimeCreatedUtc { get; set; }
        /// <summary>
        /// Gets or sets the date time read UTC.
        /// </summary>
        /// <value>
        /// The date time read UTC.
        /// </value>
        public virtual DateTimeOffset? DateTimeReadUtc { get; set; }


        //Source User or System identifier
        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        public virtual string From { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        public virtual string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        /// <value>
        /// The class.
        /// </value>
        public virtual string Class { get; set; }

        /// <summary>
        ///     Status whether Message has been read.
        /// </summary>
        public virtual bool IsRead
        {
            get => this.DateTimeReadUtc.HasValue;
            set
            {
                if (value == false)
                {
                    this.DateTimeReadUtc = null;
                }
                else
                {
                    if (!this.DateTimeReadUtc.HasValue)
                    {
                        this.DateTimeReadUtc = DateTimeOffset.UtcNow;
                    }
                }
            }
        }

        /// <summary>
        ///     1-100% complete.
        /// </summary>
        public virtual int Value { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public virtual string Text { get; set; }
    }
}
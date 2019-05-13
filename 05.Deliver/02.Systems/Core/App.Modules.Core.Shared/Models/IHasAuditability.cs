namespace App.Modules.Core.Shared.Models
{
    using System;

    public interface IHasInRecordAuditability
    {
        /// <summary>
        ///     Gets or sets the created on.
        /// </summary>
        DateTimeOffset? CreatedOnUtc { get; set; }


        /// <summary>
        ///     Gets or sets the created by.
        /// </summary>
        string CreatedByPrincipalId { get; set; }

        /// <summary>
        ///     Gets or sets the last modified on.
        /// </summary>
        DateTimeOffset? LastModifiedOnUtc { get; set; }

        /// <summary>
        ///     Gets or sets the last modified by.
        /// </summary>
        string LastModifiedByPrincipalId { get; set; }

        /// <summary>
        ///     Gets or sets the last modified on.
        /// </summary>
        DateTimeOffset? DeletedOnUtc { get; set; }

        /// <summary>
        ///     Gets or sets the last modified by.
        /// </summary>
        string DeletedByPrincipalId { get; set; }
    }
}
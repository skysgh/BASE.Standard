// Copyright MachineBrains, Inc. 2019

using System;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract to define that the model
    ///     has sufficient attributes to record who and when
    ///     created, updated, and deleted a record.
    /// </summary>
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
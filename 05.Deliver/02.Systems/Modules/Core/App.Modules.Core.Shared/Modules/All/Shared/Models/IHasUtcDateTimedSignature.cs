// Copyright MachineBrains, Inc. 2019

using System;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for a model that has a
    ///     <see cref="UtcDateTimeUpdated" />
    ///     and
    ///     <see cref="Signature" />
    ///     property.
    /// </summary>
    public interface IHasDateTimedSignature
    {
        /// <summary>
        ///     Gets or sets the utc date time when the record was last updated.
        /// </summary>
        /// <value>
        ///     The date time updated.
        /// </value>
        DateTimeOffset UtcDateTimeUpdated { get; set; }

        /// <summary>
        ///     Gets or sets the digital signature of the record's protected attributes.
        /// </summary>
        string Signature { get; set; }
    }
}
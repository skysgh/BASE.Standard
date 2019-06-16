using System;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for a model that has a
    /// <see cref="UtcDateTimeCreated"/>
    /// property.
    /// </summary>
    public interface IHasDateTimeCreatedUtc
    {
        /// <summary>
        /// Gets or sets the UTC date time when the record was created.
        /// </summary>
        DateTimeOffset UtcDateTimeCreated { get; set; }
    }
}
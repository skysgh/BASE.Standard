// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models
{
    /// Contract for a model that has a
    /// <see cref="Timestamp" />
    /// property.
    public interface IHasTimestamp
    {
        /// <summary>
        ///     Gets or sets the datastore concurrency check timestamp.
        ///     <para>
        ///         Note that this is filled in when persisted in the db --
        ///         so it's usable to determine whether Record is New or not.
        ///     </para>
        /// </summary>
        byte[] Timestamp { get; set; }
    }
}
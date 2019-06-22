// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for a model that has an <see cref="IsResourced" />
    ///     property.
    /// </summary>
    public interface IHasIsResourced
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this instance is resourced.
        ///     TODO: Can't remember what this was about.
        /// </summary>
        bool IsResourced { get; set; }
    }
}
// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for a model that has a
    ///     <see cref="Description" />
    ///     property.
    /// </summary>
    public interface IHasDescription
    {
        /// <summary>
        ///     Gets or sets the optional displayed description.
        /// </summary>
        string Description { get; set; }
    }
}
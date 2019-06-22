// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models
{
    /// Contract for a model that has a
    /// <c>Text</c>
    /// property.
    public interface IHasText
    {
        /// <summary>
        ///     Gets or sets the displayed title.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        string Title { get; set; }
    }
}
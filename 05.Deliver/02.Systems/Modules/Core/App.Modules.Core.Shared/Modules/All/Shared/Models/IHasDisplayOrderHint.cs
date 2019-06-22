// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for a model that has a
    ///     <see cref="DisplayOrderHint" />
    ///     property.
    /// </summary>
    public interface IHasDisplayOrderHint
    {
        /// <summary>
        ///     A convention based hint as to the natural order in which to display this list item
        ///     (note that the natural order can be superseded/influenced by MRU information, etc.)
        /// </summary>
        int DisplayOrderHint { get; set; }
    }
}
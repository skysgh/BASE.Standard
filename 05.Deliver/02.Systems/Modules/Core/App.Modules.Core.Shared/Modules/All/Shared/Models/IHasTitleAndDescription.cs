// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for a model that has a
    ///     <see cref="IHasTitle.Title" />
    ///     and
    ///     <see cref="IHasDescription.Description" />
    ///     property.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTitle" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasDescription" />
    public interface IHasTitleAndDescription : IHasTitle, IHasDescription
    {
    }
}
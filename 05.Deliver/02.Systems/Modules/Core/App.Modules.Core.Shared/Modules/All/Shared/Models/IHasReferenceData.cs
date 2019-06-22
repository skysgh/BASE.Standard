// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for a model that has a
    ///     <see cref="IHasEnabled" />
    ///     <see cref="IHasTitle" />
    ///     and
    ///     <see cref="IHasDescription" />
    ///     property.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasEnabled" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTitleAndDescription" />
    public interface IHasReferenceData :
        IHasEnabled,
        IHasTitleAndDescription
    {
    }
}
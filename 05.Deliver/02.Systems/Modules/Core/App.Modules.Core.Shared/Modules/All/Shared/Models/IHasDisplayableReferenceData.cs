// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     A contract for a single ReferenceData record
    ///     with information as to order and rendering hints.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasReferenceData" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasDisplayOrderHint" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasDisplayStyleHint" />
    public interface IHasDisplayableReferenceData :
        IHasReferenceData,
        IHasDisplayOrderHint,
        IHasDisplayStyleHint
    {
    }
}
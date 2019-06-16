using System;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for a model that has a
    /// Id
    /// property.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasId{Guid}" />
    public interface IHasGuidId : IHasId<Guid>

    {

    }
}
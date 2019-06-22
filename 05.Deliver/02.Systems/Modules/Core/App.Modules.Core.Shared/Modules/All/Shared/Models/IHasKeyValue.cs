// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for a model that has a
    ///     Key
    ///     property.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasKey" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasValue{T}" />
    public interface IHasKeyValue<T> : IHasKey, IHasValue<T>
    {
    }
}
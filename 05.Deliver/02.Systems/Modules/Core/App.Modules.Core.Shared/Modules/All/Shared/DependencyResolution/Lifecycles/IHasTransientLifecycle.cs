// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.DependencyResolution.Lifecycles
{
    /// <summary>
    ///     Register the service such that a new one is created every
    ///     time a service is requested.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.DependencyResolution.Lifecycles.IHasLifecycle" />
    public interface IHasTransientLifecycle : IHasLifecycle
    {
    }
}
// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Infrastructure.Contracts
{
    /// <summary>
    ///     <para>
    ///         See  <see cref="IHasInitialized" />
    ///         and <see cref="IHasInitialize" />
    ///     </para>
    ///     <para>
    ///         Resets the flag behind <see cref="IHasInitialized.Initialized" />
    ///         (which is often a static field)
    ///     </para>
    /// </summary>
    public interface IHasResetInitialization
    {
        void Reset();
    }
}
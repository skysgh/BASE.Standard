// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Initialization
{
    /// <summary>
    ///     Contract for methods that have an Initialize() method.
    /// </summary>
    public interface IHasInitialize
    {
        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        void Initialize();
    }


    /// <summary>
    ///     Contract for methods that have an Initialize() method.
    /// </summary>
    public interface IHasInitialize<in T>
    {
        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        void Initialize(T argument);
    }
}
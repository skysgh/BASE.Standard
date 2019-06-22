// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models
{
    /// Contract for a model that has a
    /// <see cref="Initialize" />
    /// method.
    public interface IInitialize
    {
        /// <summary>
        ///     Method to invoke to initialize this object.
        ///     <para>
        ///         TODO: Consider that modern DI based development patterns are moving
        ///         such operations into the constructor.
        ///     </para>
        /// </summary>
        void Initialize();
    }
}
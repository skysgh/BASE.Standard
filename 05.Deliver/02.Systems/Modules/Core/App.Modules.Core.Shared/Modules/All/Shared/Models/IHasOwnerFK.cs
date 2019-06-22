// Copyright MachineBrains, Inc. 2019

using System;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for a model that has a
    ///     <see cref="GetOwnerFk" />
    ///     method.
    /// </summary>
    public interface IHasOwnerFK
    {
        /// <summary>
        ///     Returns the FK of the
        ///     parent, owning entity.
        /// </summary>
        Guid GetOwnerFk();
    }
}
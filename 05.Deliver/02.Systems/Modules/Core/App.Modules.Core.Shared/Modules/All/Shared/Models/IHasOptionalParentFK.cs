// Copyright MachineBrains, Inc. 2019

using System;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for a model that has a
    ///     <see cref="ParentFK" />
    ///     property.
    ///     <para>
    ///         See <see cref="IHasRequiredParentFK" />
    ///     </para>
    /// </summary>
    public interface IHasOptionalParentFK
    {
        /// <summary>
        ///     Gets or sets the FK
        ///     of an optional
        ///     parent.
        /// </summary>
        Guid? ParentFK { get; set; }
    }
}
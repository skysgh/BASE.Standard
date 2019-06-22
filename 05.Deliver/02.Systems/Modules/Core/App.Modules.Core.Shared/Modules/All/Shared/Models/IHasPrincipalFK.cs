// Copyright MachineBrains, Inc. 2019

using System;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for a model that has a
    ///     <see cref="PrincipalFK" />
    ///     property.
    /// </summary>
    public interface IHasPrincipalFK
    {
        /// <summary>
        ///     Gets or sets the FK of the Principal.
        ///     <para>
        ///         Note that as as the property name
        ///         ends with FK (and not Id)
        ///         it is Db enforced, and not just a weak
        ///         reference.
        ///     </para>
        /// </summary>
        Guid PrincipalFK { get; set; }
    }
}
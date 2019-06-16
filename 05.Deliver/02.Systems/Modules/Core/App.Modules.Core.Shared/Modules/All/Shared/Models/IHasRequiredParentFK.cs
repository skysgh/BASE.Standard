using System;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for a model that has a
    /// <see cref="ParentFK"/>
    /// property.
    /// <para>
    /// See <see cref="IHasOptionalParentFK"/>
    /// </para>
    /// </summary>
    public interface IHasRequiredParentFK
    {
        /// <summary>
        /// Gets or sets the FK of the parent record.
        /// </summary>
        Guid ParentFK { get; set; }
    }
}
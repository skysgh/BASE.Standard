using System;

namespace App.Modules.Core.Shared.Models
{
    /// <summary>
    /// <para>
    /// See <see cref="IHasOptionalParentFK"/>
    /// </para>
    /// </summary>
    public interface IHasRequiredParentFK
    {
        Guid ParentFK { get; set; }
    }
}
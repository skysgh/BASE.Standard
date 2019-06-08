using System;

namespace App.Modules.All.Shared.Models
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
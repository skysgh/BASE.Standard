using System;

namespace App.Modules.Core.Shared.Models
{
    /// <summary>
    /// 
    /// <para>
    /// See <see cref="IHasRequiredParentFK"/>
    /// </para>
    /// </summary>
    public interface IHasOptionalParentFK {
        Guid? ParentFK { get; set; }
    }


}
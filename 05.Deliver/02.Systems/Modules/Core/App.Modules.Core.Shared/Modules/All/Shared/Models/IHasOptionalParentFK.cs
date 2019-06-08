using System;

namespace App.Modules.All.Shared.Models
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
﻿namespace App.Modules.Core.Shared.Models
{
    public interface IHasParent<T> : IHasOptionalParentFK
    {
        T Parent { get; set; }
    }


}
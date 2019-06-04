namespace App.Modules.Core.Models
{
    public interface IHasParent<T> : IHasOptionalParentFK
    {
        T Parent { get; set; }
    }


}
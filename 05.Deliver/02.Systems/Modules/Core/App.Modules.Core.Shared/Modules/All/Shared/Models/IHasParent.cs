namespace App.Modules.All.Shared.Models
{
    public interface IHasParent<T> : IHasOptionalParentFK
    {
        T Parent { get; set; }
    }


}
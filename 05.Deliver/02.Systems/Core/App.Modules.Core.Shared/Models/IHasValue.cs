namespace App.Modules.Core.Shared.Models
{
    public interface IHasValue<T>
    {
        T Value { get; set; }
    }
}
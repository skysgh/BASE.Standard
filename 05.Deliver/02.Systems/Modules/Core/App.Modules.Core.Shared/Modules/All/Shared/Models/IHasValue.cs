namespace App.Modules.All.Shared.Models
{
    public interface IHasValue<T>
    {
        T Value { get; set; }
    }
}
namespace App.Modules.Core.Models
{
    public interface IHasValue<T>
    {
        T Value { get; set; }
    }
}
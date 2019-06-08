namespace App.Modules.All.Shared.Models
{
    public interface IHasKeyValue<T> : IHasKey, IHasValue<T>
    {
    }
}
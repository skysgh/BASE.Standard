namespace App.Modules.Core.Shared.Models
{
    public interface IHasKeyValue<T> : IHasKey, IHasValue<T>
    {
    }
}
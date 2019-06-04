namespace App.Modules.Core.Models
{
    public interface IHasKeyValue<T> : IHasKey, IHasValue<T>
    {
    }
}
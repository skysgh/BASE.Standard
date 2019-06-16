namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for a model that
    /// has Children.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHasChildren<T> where T : IHasGuidId
    {
    }
}
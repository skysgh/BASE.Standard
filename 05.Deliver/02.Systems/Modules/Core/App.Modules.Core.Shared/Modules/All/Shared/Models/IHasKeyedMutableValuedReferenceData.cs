namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Base class to more easily define
    /// compliant mutable reference Data with a
    /// Guid Id, and a
    /// Generic Typed value.
    /// </summary>
    /// <typeparam name="TValue">The type of the Value.</typeparam>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasMutableValuedReferenceData{TValue}" />
    public interface IHasKeyedMutableValuedReferenceData<TValue> 
        : IHasMutableValuedReferenceData<TValue>
    {

    }
}
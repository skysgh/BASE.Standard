namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for a model that has a
    /// <see cref="DisplayStyleHint"/>
    /// property.
    /// </summary>
    public interface IHasDisplayStyleHint
    {
        /// <summary>
        /// A convention based hint as to display (could be a class name, or icon, CSV or both, DSL, etc.)
        /// </summary>
        string DisplayStyleHint { get; set; }
    }
}
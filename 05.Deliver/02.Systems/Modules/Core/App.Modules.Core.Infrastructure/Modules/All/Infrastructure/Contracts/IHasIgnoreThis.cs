namespace App.Modules.All.Infrastructure.Contracts
{
    /// <summary>
    /// Contract that can be attached to classes that need to be ignored (eg: by Reflection)
    /// <para>
    /// Have used to ignore some Entity Framework Schema definitions, etc.
    /// </para>
    /// </summary>
    public interface IHasIgnoreThis 
    {
    }
}

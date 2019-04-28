namespace App.Modules.Core.Infrastructure.Initialization
{
    // A non-functional contract (more or less a 'tag') 
    // to help track down all the various initializers.
    public interface IHasInitializer
    {
    }

    /// <summary>
    /// The initializer is specific to a Module
    /// <para>
    /// A non-functional contract (more or less a 'tag') 
    /// to help track down all the various initializers.
    /// </para>
    /// </summary>
    public interface IHasAppModuleInitializer : IHasInitializer
    {

    }

    /// <summary>
    /// The initializer is for the whole app
    /// <para>
    /// A non-functional contract (more or less a 'tag') 
    /// to help track down all the various initializers.
    /// </para>
    /// </summary>
    public interface IHasModuleInitializer : IHasInitializer
    {

    }

}
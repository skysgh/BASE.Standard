﻿namespace App.Modules.Core.Infrastructure.Initialization
{
    /// <summary>
    /// The initializer is specific to a Module
    /// <para>
    /// A non-functional contract (more or less a 'tag') 
    /// to help track down all the various initializers.
    /// </para>
    /// </summary>
    public interface IHasModuleSpecificInitializer : IHasInitializer
    {

    }

}
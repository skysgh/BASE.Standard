using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.KWMODULE.Domain.Services.Implementations
{
    /// <summary>
    /// Implementation of
    /// <see cref="IExampleDomainService"/>
    /// <para>
    /// Invoked from an Application Service.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Modules.KWMODULE.Domain.Services.IExampleDomainService" />
    public class ExampleDomainService : IExampleDomainService
    {
        /// <summary>
        /// Does something.
        /// </summary>
        /// <returns></returns>
        public string DoSomething()
        {
            return "World";
        }
    }
}

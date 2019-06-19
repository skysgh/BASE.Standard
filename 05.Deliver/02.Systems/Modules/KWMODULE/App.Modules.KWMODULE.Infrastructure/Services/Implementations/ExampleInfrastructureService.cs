using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.KWMODULE.Infrastructure.Services.Implementations
{
    /// <summary>
    /// Implementation of <see cref="IExampleInfrastructureService"/>
    /// invoked (along with Domain Services)
    /// by an Application Service.
    /// </summary>
    /// <seealso cref="App.Modules.KWMODULE.Infrastructure.Services.IExampleInfrastructureService" />
    public class ExampleInfrastructureService : IExampleInfrastructureService
    {
        /// <summary>
        /// Does something.
        /// </summary>
        /// <returns></returns>
        public string DoSomething()
        {
            return "Hello";
        }
    }
}

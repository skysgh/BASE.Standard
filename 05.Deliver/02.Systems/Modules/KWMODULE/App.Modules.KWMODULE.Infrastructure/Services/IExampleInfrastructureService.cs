using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.All.Infrastructure.Services;

namespace App.Modules.KWMODULE.Infrastructure.Services
{
    /// <summary>
    /// Example of an Infrastructure Service,
    /// invoked by an Application Service.
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.Services.IInfrastructureService" />
    public interface IExampleInfrastructureService :IInfrastructureService
    {
        /// <summary>
        /// Does something.
        /// </summary>
        /// <returns></returns>
        string DoSomething();
    }
}

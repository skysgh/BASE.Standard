using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.KWMODULE.Application.Services
{
    /// <summary>
    /// Contract for an example Application Service
    /// invoked by an AppFacade Controller.
    /// </summary>
    public interface IExampleApplicationService
    {
        /// <summary>
        /// Does something.
        /// </summary>
        /// <returns></returns>
        string DoSomething();
    }
}

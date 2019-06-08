using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.All.Infrastructure.Services;

namespace App.Modules.KWMODULE.Infrastructure.Services
{
    public interface IExampleInfrastructureService :IInfrastructureService
    {
        string DoSomething();
    }
}

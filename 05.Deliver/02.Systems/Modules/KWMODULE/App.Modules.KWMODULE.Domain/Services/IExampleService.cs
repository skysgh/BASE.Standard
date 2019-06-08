using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.All.Domain;

namespace App.Modules.KWMODULE.Domain.Services
{
    public interface IExampleDomainService : IDomainService
    {
        string DoSomething();
    }
}

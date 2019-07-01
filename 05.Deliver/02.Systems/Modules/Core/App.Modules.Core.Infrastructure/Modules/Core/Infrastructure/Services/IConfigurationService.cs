using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IConfigurationService
    {
        TConfigurationObject Get<TConfigurationObject>();
        void Get<TConfigurationObject>(TConfigurationObject target);

    }
}
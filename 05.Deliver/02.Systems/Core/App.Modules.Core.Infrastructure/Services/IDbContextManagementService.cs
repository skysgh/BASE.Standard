using App.Modules.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Infrastructure.Data.Db;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IAppDbContextManagementService : IAppModuleCoreService
    {
        void Register(ModuleDbContextBase dbContext);

    }
}

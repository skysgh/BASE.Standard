using App.Modules.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Infrastructure.Data.Db;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    public class AppDbContextManagementService : IAppDbContextManagementService
    {

        Queue<AppModuleDbContextBase> _openedContexts = new Queue<AppModuleDbContextBase>();

        public void Register(AppModuleDbContextBase dbContext)
        {
            if (_openedContexts.Contains(dbContext))
            {
                return;
            }
            _openedContexts.Enqueue(dbContext);
        }

        public void SaveChanges()
        {
            while (_openedContexts.Count > 0)
            {
                AppModuleDbContextBase dbContext = _openedContexts.Dequeue();

                dbContext.PrepareToSave();
                dbContext.SaveChanges();
            }
        }
    }
}

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

        Queue<ModuleDbContextBase> _openedContexts = new Queue<ModuleDbContextBase>();

        public void Register(ModuleDbContextBase dbContext)
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
                ModuleDbContextBase dbContext = _openedContexts.Dequeue();

                dbContext.PrepareToSave();
                dbContext.SaveChanges();
            }
        }
    }
}

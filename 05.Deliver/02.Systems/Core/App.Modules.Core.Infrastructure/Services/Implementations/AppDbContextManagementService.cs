using App.Modules.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    public class AppDbContextManagementService : IAppDbContextManagementService
    {

        Queue<AppDbContextBase> _openedContexts = new Queue<AppDbContextBase>();

        public void Register(AppDbContextBase dbContext)
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
                AppDbContextBase dbContext = _openedContexts.Dequeue();

                dbContext.PrepareToSave();
                dbContext.SaveChanges();
            }
        }
    }
}

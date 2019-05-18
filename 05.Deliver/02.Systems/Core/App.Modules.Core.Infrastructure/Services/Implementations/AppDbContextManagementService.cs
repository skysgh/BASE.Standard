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
        private readonly IOperationContextService _operationContextService;
        private readonly IDbContextPreCommitService _dbContextPreCommitService;
        public AppDbContextManagementService(
            IOperationContextService operationContextService,
            IDbContextPreCommitService dbContextPreCommitService)
        {
            _operationContextService = operationContextService;
            _dbContextPreCommitService = dbContextPreCommitService;
        }
        public DbContext[] DbContexts => _openedContexts.ToArray();

        protected List<ModuleDbContextBase> _openedContexts
        {
            get
            {
                var key = "DbContexts";
                var r = _operationContextService.Get<List<ModuleDbContextBase>>(key);
                if (r == null)
                {
                    r = new List<ModuleDbContextBase>();
                    _operationContextService.Set(key, r);
                }
                return r;
            }
        }


        public void Register(ModuleDbContextBase dbContext)
        {
            if (_openedContexts.Contains(dbContext))
            {
                return;
            }
            _openedContexts.Add(dbContext);
        }

        public void SaveChanges()
        {
            foreach (var dbContext in _openedContexts)
            {
                try
                {
                    _dbContextPreCommitService.PreProcess(dbContext);
                    dbContext.PrepareToSave();
                    dbContext.SaveChanges();
                }catch (System.Exception e)
                {
                    throw e;
                }
            }
        }
    }
}

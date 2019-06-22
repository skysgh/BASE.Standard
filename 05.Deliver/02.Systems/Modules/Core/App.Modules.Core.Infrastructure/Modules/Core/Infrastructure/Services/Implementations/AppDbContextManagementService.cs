// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using App.Modules.All.Infrastructure.Data.Db.Contexts;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    public class AppDbContextManagementService : IAppDbContextManagementService
    {
        private readonly IDbContextPreCommitService _dbContextPreCommitService;
        private readonly IOperationContextService _operationContextService;

        public AppDbContextManagementService(
            IOperationContextService operationContextService,
            IDbContextPreCommitService dbContextPreCommitService)
        {
            _operationContextService = operationContextService;
            _dbContextPreCommitService = dbContextPreCommitService;
        }

        protected List<ModuleDbContextBase> _openedContexts
        {
            get
            {
                var key = "DbContexts";
                List<ModuleDbContextBase> r = _operationContextService.Get<List<ModuleDbContextBase>>(key);
                if (r == null)
                {
                    r = new List<ModuleDbContextBase>();
                    _operationContextService.Set(key, r);
                }

                return r;
            }
        }

        public DbContext[] DbContexts => _openedContexts.ToArray();


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
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
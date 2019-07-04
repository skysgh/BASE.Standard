// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Constants.Context;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISessionOperationLogService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.ISessionOperationLogService" />
    public class SessionOperationLogService : AppCoreServiceBase, ISessionOperationLogService
    {
        private readonly ModuleDbContext _coreRepositoryService;
        private readonly IOperationContextService _operationContextService;

        public SessionOperationLogService(IOperationContextService operationContextService,
            ModuleDbContext repositoryService)
        {
            _operationContextService = operationContextService;
            _coreRepositoryService = repositoryService;
        }


        public SessionOperation Current
        {
            get
            {
                var r = _operationContextService.Get<SessionOperation>(AppContextKeys.SessionOperation);

                if (r != null)
                {
                    return r;
                }

                r = new SessionOperation();
                _operationContextService.Set(AppContextKeys.SessionOperation, r);


                return r;
            }
        }

        public object GetDetail(string key)
        {
            Dictionary<string, object> d = CurrentDetails;
            object r;
            if (d.TryGetValue(key, out r))
            {
                return r;
            }

            return null;
        }

        public void SetDetail(string key, object value)
        {
            Dictionary<string, object> d = CurrentDetails;
            d[key] = value;
        }

        public void IncrementDetail(string key)
        {
            Dictionary<string, object> d = CurrentDetails;
            object r;
            if (d.TryGetValue(key, out r))
            {
                r = (int) r + 1;
                return;
            }

            d[key] = 1;
        }


        public Dictionary<string, object> CurrentDetails
        {
            get
            {
                Dictionary<string, object> r =
                    _operationContextService.Get<Dictionary<string, object>>(AppContextKeys.SessionOperationDetails);

                if (r != null)
                {
                    return r;
                }

                r = new Dictionary<string, object>();
                _operationContextService.Set(AppContextKeys.SessionOperationDetails, r);
                return r;
            }
        }
    }
}
using System;
using App.Modules.Core.Infrastructure.Data.Db;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    using App.Modules.Core.Shared.Models.Entities;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISystemRoleRecordManagmentService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.ISystemRoleRecordManagmentService" />
    public class SystemRoleRecordManagmentService : AppCoreServiceBase, ISystemRoleRecordManagmentService
    {
        private readonly ModuleDbContext _coreRepositoryService;

        public SystemRoleRecordManagmentService(ModuleDbContext repositoryService)
        {
            this._coreRepositoryService = repositoryService;
        }


        public SystemRole GetSystemRoleByDataStoreId(Guid id)
        {
            var result = this._coreRepositoryService.GetSingle<SystemRole>(x => x.Id == id);
            return result;
        }

        public SystemRole GetByKey(string key)
        {
            var result = this._coreRepositoryService.GetSingle<SystemRole>(x => x.Key == key);
            return result;
        }
    }
}

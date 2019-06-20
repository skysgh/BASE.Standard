using System;

using App.Modules.Core.Infrastructure.Services.Implementations.Base;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    using App.Modules.Core.Infrastructure.Data.Db.Contexts;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISystemRoleRecordManagementService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.ISystemRoleRecordManagementService" />
    public class SystemRoleRecordManagementService : AppCoreServiceBase, ISystemRoleRecordManagementService
    {
        private readonly ModuleDbContext _coreRepositoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemRoleRecordManagementService"/> class.
        /// </summary>
        /// <param name="repositoryService">The repository service.</param>
        public SystemRoleRecordManagementService(ModuleDbContext repositoryService)
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

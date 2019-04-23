using System;

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
        private readonly IRepositoryService _repositoryService;

        public SystemRoleRecordManagmentService(IRepositoryService repositoryService)
        {
            this._repositoryService = repositoryService;
        }


        public SystemRole GetSystemRoleByDataStoreId(Guid id)
        {
            var result = this._repositoryService.GetSingle<SystemRole>(Constants.Db.CoreModuleDbContextNames.Core, x => x.Id == id);
            return result;
        }

        public SystemRole GetByKey(string key)
        {
            var result = this._repositoryService.GetSingle<SystemRole>(Constants.Db.CoreModuleDbContextNames.Core, x => x.Key == key);
            return result;
        }
    }
}

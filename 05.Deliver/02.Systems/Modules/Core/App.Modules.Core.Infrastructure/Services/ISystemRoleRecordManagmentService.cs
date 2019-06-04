using System;
using App.Modules.Core.Models.Entities;


namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    /// Service to manage the Record of Roles associated
    /// to <see cref="Principal"/> records.
    /// </summary>
    public interface ISystemRoleRecordManagmentService : IModuleSpecificService
    {
        /// <summary>
        /// Gets a System (ie, universal across Tenants) Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SystemRole GetSystemRoleByDataStoreId(Guid id);
    }
}

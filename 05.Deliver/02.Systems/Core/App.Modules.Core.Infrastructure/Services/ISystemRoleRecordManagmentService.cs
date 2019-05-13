﻿using System;


namespace App.Modules.Core.Infrastructure.Services
{
    using App.Modules.Core.Shared.Models.Entities;

    /// <summary>
    /// Service to manage the Record of Roles associated
    /// to <see cref="Principal"/> records.
    /// </summary>
    public interface ISystemRoleRecordManagmentService : IAppModuleCoreService
    {
        /// <summary>
        /// Gets a System (ie, universal across Tenants) Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SystemRole GetSystemRoleByDataStoreId(Guid id);
    }
}
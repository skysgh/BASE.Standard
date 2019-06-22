﻿// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Service to manage the Record of Roles associated
    ///     to <see cref="Principal" /> records.
    /// </summary>
    public interface ISystemRoleRecordManagementService : IInfrastructureService
    {
        /// <summary>
        ///     Gets a System (ie, universal across Tenants) Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SystemRole GetSystemRoleByDataStoreId(Guid id);
    }
}
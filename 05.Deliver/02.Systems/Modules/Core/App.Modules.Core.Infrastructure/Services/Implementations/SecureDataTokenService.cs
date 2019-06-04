﻿using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;
using App.Modules.Core.Models.Entities;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    using System;
    using App.Modules.Core.Infrastructure.Constants;
    using App.Modules.Core.Infrastructure.Constants.Db;
    using App.Modules.Core.Infrastructure.Data.Db.Contexts;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISecureDataTokenService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.ISecureDataTokenService" />
    public class SecureDataTokenService : AppCoreServiceBase, ISecureDataTokenService
    {
        private readonly ModuleDbContext _coreRepositoryService;

        public SecureDataTokenService(ModuleDbContext repositoryService)
        {
            this._coreRepositoryService = repositoryService;
        }

        public string Get(Guid tokenKey)
        {
            var result = this._coreRepositoryService.GetSingle<DataToken>(x => x.Id == tokenKey)?.Value;

            return result;
        }

        public string Save(string value)
        {
            var dataToken = new DataToken();
            dataToken.Value = value;
            this._coreRepositoryService.AddOnCommit(dataToken);

            return dataToken.Id.ToString("D").ToLower();
        }
    }
}
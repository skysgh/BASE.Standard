// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
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
            _coreRepositoryService = repositoryService;
        }

        public string Get(Guid tokenKey)
        {
            var result = _coreRepositoryService.GetSingle<DataToken>(x => x.Id == tokenKey)?.Value;

            return result;
        }

        public string Save(string value)
        {
            var dataToken = new DataToken();
            dataToken.Value = value;
            _coreRepositoryService.AddOnCommit(dataToken);

            return dataToken.Id.ToString("D").ToLower();
        }
    }
}
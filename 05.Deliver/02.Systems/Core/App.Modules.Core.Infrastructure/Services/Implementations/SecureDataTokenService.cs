namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    using System;
    using App.Modules.Core.Infrastructure.Constants;
    using App.Modules.Core.Infrastructure.Constants.Db;
    using App.Modules.Core.Shared.Models.Entities;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISecureDataTokenService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.ISecureDataTokenService" />
    public class SecureDataTokenService : AppCoreServiceBase, ISecureDataTokenService
    {
        private readonly IRepositoryService _repositoryService;

        public SecureDataTokenService(IRepositoryService repositoryService)
        {
            this._repositoryService = repositoryService;
        }

        public string Get(Guid tokenKey)
        {
            var result = this._repositoryService.GetSingle<DataToken>(CoreModuleDbContextNames.Core, x => x.Id == tokenKey)?.Value;

            return result;
        }

        public string Save(string value)
        {
            var dataToken = new DataToken();
            dataToken.Value = value;
            this._repositoryService.AddOnCommit(CoreModuleDbContextNames.Core, dataToken);

            return dataToken.Id.ToString("D").ToLower();
        }
    }
}
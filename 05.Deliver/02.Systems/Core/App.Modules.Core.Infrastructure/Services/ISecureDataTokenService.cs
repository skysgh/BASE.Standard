namespace App.Modules.Core.Infrastructure.Services
{
    using System;
    using App.Modules.Core.Shared.Contracts.Services;

    internal interface ISecureDataTokenService : IAppModuleCoreService
    {
        string Get(Guid tokenKey);
        string Save(string value);
    }
}
namespace App.Modules.Core.Infrastructure.Services
{
    using System;
    using App.Modules.Core.Shared.Contracts.Services;

    internal interface ISecureDataTokenService : IModuleSpecificService
    {
        string Get(Guid tokenKey);
        string Save(string value);
    }
}
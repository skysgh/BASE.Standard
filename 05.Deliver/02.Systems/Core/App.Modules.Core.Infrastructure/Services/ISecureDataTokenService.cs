namespace App.Modules.Core.Infrastructure.Services
{
    using System;
    using App.Modules.Core.Shared.Services;

    internal interface ISecureDataTokenService : IHasAppCoreService
    {
        string Get(Guid tokenKey);
        string Save(string value);
    }
}
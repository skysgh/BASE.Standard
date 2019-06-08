using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    using System;

    internal interface ISecureDataTokenService : IInfrastructureService
    {
        string Get(Guid tokenKey);
        string Save(string value);
    }
}
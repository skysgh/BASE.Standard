// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    internal interface ISecureDataTokenService : IInfrastructureService
    {
        string Get(Guid tokenKey);
        string Save(string value);
    }
}
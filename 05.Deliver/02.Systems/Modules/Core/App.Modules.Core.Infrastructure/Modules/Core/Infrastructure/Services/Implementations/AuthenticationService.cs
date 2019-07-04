// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IAuthenticationService" />
    ///     Infrastructure Service Contract
    /// </summary>
    public class AuthenticationService : AppCoreServiceBase, IAuthenticationService
    {
        public bool Authenticate(string nameCredential, string passwordCredential)
        {
            throw new NotImplementedException();
        }
    }
}
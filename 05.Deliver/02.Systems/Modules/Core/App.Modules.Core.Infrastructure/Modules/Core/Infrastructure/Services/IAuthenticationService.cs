// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for an Infrastructure Service to
    ///     Authenticate a User
    ///     against an internal Store.
    /// </summary>
    public interface IAuthenticationService : IInfrastructureService
    {
        /// <summary>
        ///     Authenticate a user's credentials - but only if the
        ///     app is persisting Principal credentials, which it REALLY
        ///     should NOT be doing.
        /// </summary>
        /// <param name="nameCredential"></param>
        /// <param name="passwordCredential"></param>
        /// <returns></returns>
        bool Authenticate(string nameCredential, string passwordCredential);
    }
}
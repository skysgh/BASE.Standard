// Copyright MachineBrains, Inc. 2019

using System.Linq;
using App.Modules.Core.Infrastructure.Constants.IDA;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IAuthorisationService" />
    ///     Infrastructure Service Contract
    ///     to Query whether the current Thread's Principal
    ///     is Authorised to perform specific Operations.
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IAuthorisationService" />
    public class AuthorisationService : AppCoreServiceBase, IAuthorisationService
    {
        private readonly IPrincipalService _principalService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthorisationService" /> class.
        /// </summary>
        /// <param name="principalService">The principal service.</param>
        public AuthorisationService(IPrincipalService principalService)
        {
            _principalService = principalService;
        }

        /// <summary>
        ///     Determines whether the current thread Principal has roles claims.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns>
        ///     <c>true</c> if the specified roles has roles; otherwise, <c>false</c>.
        /// </returns>
        public bool HasRoles(params string[] roles)
        {
            return roles.Any(x => _principalService.CurrentPrincipal.IsInRole(x));
        }

        /// <summary>
        ///     Determines whether the current thread Principal has scope.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <returns>
        ///     <c>true</c> if the specified scope has scope; otherwise, <c>false</c>.
        /// </returns>
        public bool HasScope(string scope)
        {
            var scopeElement = ClaimTitles.ScopeElementId;

            bool? value = _principalService.CurrentPrincipal?.FindFirst(scopeElement)?.Value?.Contains(scope);
            return value != null && value.Value;
        }
    }
}
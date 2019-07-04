// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using System.Security.Claims;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Constants.IDA;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IPrincipalService" />
    ///     Infrastructure Service Contract
    ///     to work with the current thread Principal.
    ///     It does not work with any datastorage (ie it does not know how to
    ///     retrieve a Principal record from the database). For that, use the
    ///     PrincipalRecordService.
    /// </summary>
    /// <seealso cref="AppCoreServiceBase" />
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IPrincipalService" />
    public class PrincipalService : AppCoreServiceBase, IPrincipalService
    {
        // OWIN auth middleware constants

        /// <summary>
        ///     Gets the current identity.
        /// </summary>
        public ClaimsIdentity CurrentIdentity => ClaimsPrincipal.Current.Identities.FirstOrDefault();

        /// <summary>
        ///     Gets the current thread's Principal's NameIdentifier (not same as ObjectIdElementId).
        /// </summary>
        /// <value>
        ///     The name of the current.
        /// </value>
        public string CurrentPrincipalName
        {
            get
            {
                //http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier (ie ID)
                // not 'Name' (ie: "SSmith").
                var signedInUserID = CurrentPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (signedInUserID == null)
                {
                    signedInUserID = "UNNOWN";
                }

                return signedInUserID;
            }
        }


        /// <summary>
        ///     Gets a value indicating whether this
        ///     thread's Principal is authenticated.
        /// </summary>
        public bool IsAuthenticated => CurrentIdentity.IsAuthenticated;

        /// <summary>
        ///     Gets the current Thread's <see cref="ClaimsPrincipal" />.
        /// </summary>
        public ClaimsPrincipal CurrentPrincipal => ClaimsPrincipal.Current;

        /// <summary>
        ///     Validate the current thread Principal has the necessary scopes.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <param name="scopeElement">The scope element.</param>
        /// <returns>
        ///     <c>true</c> if [has required scopes] [the specified permission]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasRequiredScopes(string permission, string scopeElement = ClaimTitles.ScopeElementId)
        {
            bool? value = CurrentPrincipal?.FindFirst(scopeElement)?.Value?.Contains(permission);
            return value != null && value.Value;
        }


        /// <summary>
        ///     Gets the current thread's Principal's
        ///     Object/Record Identifier
        ///     (not same as NameIdentifier).
        /// </summary>
        /// <value>
        ///     The current principal identifier.
        /// </value>
        public string CurrentPrincipalIdentifier
        {
            get
            {
                var owner = ClaimsPrincipal.Current?.FindFirst(ClaimTitles.UserIdentifier)?.Value;
                return owner;
            }
        }

        /// <summary>
        ///     Gets the current principal record identifier
        ///     as a Guid (if it can be parsed.
        /// </summary>
        public Guid? CurrentPrincipalIdentifierGuid
        {
            get
            {
                if (Guid.TryParse(CurrentPrincipalIdentifier, out var result))
                {
                    return result;
                }

                return null;
            }
        }

        /// <summary>
        ///     A unique Id assigned from the issuing Token
        /// </summary>
        public string UniqueSessionIdentifier =>
            ClaimsPrincipal.Current.FindFirst(ClaimTitles.UniqueSessionIdentifier)?.Value;

        /// <summary>
        ///     The FK to the current Session Record.
        /// </summary>
        public Guid? CurrentSessionIdentifier
        {
            get
            {
                var sessionFK = ClaimsPrincipal.Current.FindFirst(ClaimTitles.SessionIdentifier)?.Value;

                if (!string.IsNullOrWhiteSpace(sessionFK))
                {
                    var result = Guid.Parse(sessionFK);
                    return result;
                }

                return null;
            }
        }


        /// <summary>
        ///     Determines whether the
        ///     Current Principal has the specified Role(s).
        /// </summary>
        /// <param name="roles">One or more roles.</param>
        /// <returns></returns>
        public bool IsInRole(params string[] roles)
        {
            return roles.Any(x => ClaimsPrincipal.Current.IsInRole(x));
        }


        /// <summary>
        ///     Gets or sets the current identity's preferred Culture Id.
        /// </summary>
        public string ClaimPreferredCultureCode
        {
            get => GetClaimValue(ClaimTitles.CultureElementId);
            set => SetClaimValue(ClaimTitles.CultureElementId, value);
        }

        /// <summary>
        ///     The Key of the Tenant of the current Security Principal (ie, the Tenant Key within a Claim of the Thread current
        ///     Principal)
        /// </summary>
        public string PrincipalTenantKey
        {
            get => GetClaimValue(ClaimTitles.PrincipalKeyElementId);
            set => SetClaimValue(ClaimTitles.PrincipalKeyElementId, value);
        }


        private string GetClaimValue(string claimName)
        {
            var cultureInfoCode = CurrentPrincipal.FindFirst(claimName)?.Value;
            return cultureInfoCode;
        }

        private void SetClaimValue(string claimName, string value)
        {
            var claim = CurrentPrincipal.FindFirst(claimName);
            if (claim != null)
            {
                CurrentIdentity
                    .TryRemoveClaim(claim);
            }

            claim = new Claim(claimName, value);
            CurrentIdentity.AddClaim(claim);
        }
    }
}
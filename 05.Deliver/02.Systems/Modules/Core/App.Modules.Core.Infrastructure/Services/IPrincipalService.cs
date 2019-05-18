﻿namespace App.Modules.Core.Infrastructure.Services
{
    using System;
    using System.Security.Claims;
    using App.Modules.Core.Shared.Contracts.Services;

    /// <summary>
    /// Contract for an infrastructure service to 
    /// work with the current thread Principal.
    /// It does not work with any datastorage (ie it does not know how to
    /// retrieve a Principal record from the database). For that, use the
    /// PrincipalRecordService.
    /// </summary>
    public interface IPrincipalService : IModuleSpecificService
    {

        /// <summary>
        /// Gets the current Thread's <see cref="ClaimsPrincipal"/>.
        /// </summary>
        ClaimsPrincipal CurrentPrincipal
        {
            get;
        }

        /// <summary>
        /// Gets the current thread's Principal's NameIdentifier (not same as ObjectIdElementId).
        /// </summary>
        /// <value>
        /// The name of the current.
        /// </value>
        string CurrentPrincipalName { get; }

        /// <summary>
        /// A unique Id assigned from the issuing Token
        /// </summary>
        string UniqueSessionIdentifier { get; }

        /// <summary>
        /// Gets the current thread's Principal's Object/Record Identifier (not same as NameIdentifier).
        /// </summary>
        /// <value>
        /// The current principal identifier.
        /// </value>
        string CurrentPrincipalIdentifier { get; }

        Guid? CurrentPrincipalIdentifierGuid { get; }

        /// <summary>
        /// The FK to the current Session Record.
        /// </summary>
        Guid? CurrentSessionIdentifier { get; }


        bool IsAuthenticated { get; }

        string ClaimPreferredCultureCode { get; set; }

        string PrincipalTenantKey { get; set; }

        /// <summary>
        // Validate the current thread Principal has the necessary scopes.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <param name="scopeElement">The scope element.</param>
        /// <returns>
        ///   <c>true</c> if [has required scopes] [the specified permission]; otherwise, <c>false</c>.
        /// </returns>
        bool HasRequiredScopes(string permission,
            string scopeElement =  "http://schemas.microsoft.com/identity/claims/scope");
        
        /// <summary>
        /// Determines whether the Current Principal has the specified Role(s).
        /// </summary>
        /// <param name="roles">One or more roles.</param>
        bool IsInRole(params string[] roles);
    }
}
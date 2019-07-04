﻿// Copyright MachineBrains, Inc. 2019

using System;
using System.Security.Claims;
using System.Threading;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Constants.IDA;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IOIDCNotificationHandlerService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IOIDCNotificationHandlerService" />
    public class OIDCNotificationHandlerService : AppCoreServiceBase, IOIDCNotificationHandlerService
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly SemaphoreSlim _mutex;
        private readonly IPrincipalManagmentService _principalManagmentService;
        private readonly ISessionService _sessionService;

        public OIDCNotificationHandlerService(ISessionService sessionService,
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalManagmentService principalManagmentService)
        {
            _sessionService = sessionService;

            _principalManagmentService = principalManagmentService;
            _mutex = new SemaphoreSlim(1);
            _diagnosticsTracingService = diagnosticsTracingService;
        }

        public void SecurityTokenValidated(AuthenticationSuccessMessage authenticationSuccessMessage)
        {
            OnAuthenticationSuccess(authenticationSuccessMessage);
            //var identity = authenticationSuccessMessage.Identity;
            //AddSessionUniqueIdentifier(identity);
            //var principal = GetOrCreatePrincipal(authenticationSuccessMessage);
            //AddClaims(identity, principal);

            //// Now add a Session!!!
            //var session = _sessionService.CreateAndSave(principal, identity.GetSessionUniqueIdentifier());
            //identity.AddClaim(new Claim(ClaimTitles.SessionIdentifier, session.Id.ToString()));
        }

        // Invoked by OIDC flows, when successfully authenticated.
        public void OnAuthenticationSuccess(AuthenticationSuccessMessage authenticationSuccessMessage)
        {
            var identity = authenticationSuccessMessage.Identity;
            AddSessionUniqueIdentifier(identity);
            var principal = GetOrCreatePrincipal(authenticationSuccessMessage, identity.GetDurationToLive());
            AddClaims(identity, principal);
        }


        public void OnAuthorizationCodeReceived(AuthorizationCodeReceivedMessage authorizationCodeReceivedMessage)
        {
            //throw new NotImplementedException();
        }

        public void OnAuthenticationError(AuthenticationErrorMessage authenticationErrorMessage)
        {
            //throw new NotImplementedException();
        }


        private void AddClaims(ClaimsIdentity identity, Principal principal)
        {
            identity.AddClaim(new Claim(ClaimTitles.UserIdentifier, principal.Id.ToString()));
            //TODO:
            // ADD Claims that our DB has set out
        }

        private Principal GetOrCreatePrincipal(AuthenticationSuccessMessage authenticationSuccessMessage,
            TimeSpan? cacheTimeSpan = null)
        {
            var principalManagmentService =
                _principalManagmentService; //AppDependencyLocator.Current.GetInstance<PrincipalManagmentService>();
            var identity = authenticationSuccessMessage.Identity;
            var idp = identity.GetIdp();
            var sub = identity.GetSub();
            var unqiueIdentifier = identity.GetSessionUniqueIdentifier();

            var principal = principalManagmentService.Get(idp, sub, unqiueIdentifier, cacheTimeSpan);
            // I am throttling this, whilst it possibly doesn't stop mutli env
            // it limits the exposure 
            // there shouldn't be that many new user creates! 
            // arguble not to throttle, going to er on side of caution
            if (principal == null)
            {
                try
                {
                    _mutex.Wait();
                    principal = principalManagmentService.CreateIfNotExists(idp, sub,
                        authenticationSuccessMessage.UserId ?? identity.Name ?? "Service",
                        unqiueIdentifier,
                        cacheTimeSpan);
                }
                finally
                {
                    _mutex.Release();
                }

                _diagnosticsTracingService.Trace(TraceLevel.Info, $"new user created idp : {idp}, sub : {sub}");
            }

            return principal;
        }


        private string GetSessionUniqueIdentifierValue(ClaimsIdentity identity)
        {
            return (identity.GetIdp() + identity.GetSub() + identity.GetExp() + identity.GetIat()).GetHashAsString();
        }

        private void AddSessionUniqueIdentifier(ClaimsIdentity identity)
        {
            identity.AddClaim(new Claim(ClaimTitles.UniqueSessionIdentifier,
                GetSessionUniqueIdentifierValue(identity)));
        }
    }
}
// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IOIDCNotificationHandlerService : IInfrastructureService
    {
        /// <summary>
        ///     shared logic between
        /// </summary>
        /// <param name="authenticationSuccessMessage"></param>
        void OnAuthenticationSuccess(AuthenticationSuccessMessage authenticationSuccessMessage);

        void OnAuthorizationCodeReceived(AuthorizationCodeReceivedMessage authorizationCodeReceivedMessage);


        void OnAuthenticationError(AuthenticationErrorMessage authenticationErrorMessage);

        /// <summary>
        ///     Cookie based
        /// </summary>
        /// <param name="authenticationSuccessMessage"></param>
        void SecurityTokenValidated(AuthenticationSuccessMessage authenticationSuccessMessage);
    }
}
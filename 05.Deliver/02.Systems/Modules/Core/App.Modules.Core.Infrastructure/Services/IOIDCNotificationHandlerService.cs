

using App.Modules.Core.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IOIDCNotificationHandlerService : IModuleSpecificService
    {
        /// <summary>
        /// shared logic between 
        /// </summary>
        /// <param name="authenticationSuccessMessage"></param>
        void OnAuthenticationSuccess(AuthenticationSuccessMessage authenticationSuccessMessage);

        void OnAuthorizationCodeReceived(AuthorizationCodeReceivedMessage authorizationCodeReceivedMessage);


        void OnAuthenticationError(AuthenticationErrorMessage authenticationErrorMessage);

        /// <summary>
        /// Cookie based
        /// </summary>
        /// <param name="authenticationSuccessMessage"></param>
        void SecurityTokenValidated(AuthenticationSuccessMessage authenticationSuccessMessage);


    }




}

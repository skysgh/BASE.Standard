using System.Security.Claims;

namespace App.Modules.Core.Shared.Models.Messages
{
    public class AuthenticationSuccessMessage
    {

        public string UserId { get; set; }

        /// <summary>
        /// The Identity created from the claims, but not
        /// yet set on the thread.
        /// </summary>
        public ClaimsIdentity Identity { get; set; }
    }
}

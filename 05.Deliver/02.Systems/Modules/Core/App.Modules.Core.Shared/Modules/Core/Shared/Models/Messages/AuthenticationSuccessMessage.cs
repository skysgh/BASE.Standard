using System.Security.Claims;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    /// A response object
    /// </summary>
    public class AuthenticationSuccessMessage
    {

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The Identity created from the claims, but not
        /// yet set on the thread.
        /// </summary>
        public ClaimsIdentity Identity { get; set; }
    }
}

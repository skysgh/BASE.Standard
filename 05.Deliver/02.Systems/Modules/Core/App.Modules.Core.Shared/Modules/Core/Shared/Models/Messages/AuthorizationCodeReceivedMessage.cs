using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasName" />
    public class AuthorizationCodeReceivedMessage: IHasName
    {

        /// <summary>
        /// Gets or sets the unique Name
        /// of the object
        /// <para>
        /// See difference with <see cref="T:App.Modules.All.Shared.Models.IHasKey" />.
        /// </para>
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// The NameIdentifier of the Identity built from the returned IdP Credentials
        /// But not yet turned into an Thread Identity (certainly not yet turned into
        /// a BearerToken or older style cookie.
        /// </summary>
        public string SignedInUserNameIdentifier { get; set; }
    }
}
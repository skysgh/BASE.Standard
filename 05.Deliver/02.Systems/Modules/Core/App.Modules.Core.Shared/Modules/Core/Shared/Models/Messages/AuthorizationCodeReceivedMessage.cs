namespace App.Modules.Core.Shared.Models.Messages
{
    public class AuthorizationCodeReceivedMessage
    {

        public string Name { get; set; }


        /// <summary>
        /// The NameIdentifier of the Identity built from the returned IdP Credentials
        /// But not yet turned into an Thread Identity (certainly not yet turned into
        /// a BearerToken or older style cookie.
        /// </summary>
        public string SignedInUserNameIdentifier { get; set; }
    }
}
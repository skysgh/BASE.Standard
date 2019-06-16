namespace App.Modules.Core.Shared.Models.Messages
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class AuthenticationErrorMessage
    {
        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public string Error { get; set; }
        /// <summary>
        /// Gets or sets the error description.
        /// </summary>
        /// <value>
        /// The error description.
        /// </value>
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Gets or sets the error URI.
        /// </summary>
        /// <value>
        /// The error URI.
        /// </value>
        public string ErrorUri { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

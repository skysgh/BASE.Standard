namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Has validation of the given claim's value.
    /// </summary>
    public interface IHasAuthoritySignature
    {
        /// <summary>
        /// Gets or sets the authority backing the signature.
        /// </summary>
        string Authority { get; set; }

        /// <summary>
        /// Gets or sets the authority's digital signature
        /// of the protected attribute(s).
        /// </summary>
        string AuthoritySignature { get; set; }

    }
}
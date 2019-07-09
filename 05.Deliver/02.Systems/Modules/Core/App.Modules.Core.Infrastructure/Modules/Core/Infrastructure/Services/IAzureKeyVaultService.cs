// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;
using System.Threading.Tasks;
using App.Modules.All.Infrastructure.Services;
using App.Modules.All.Shared.Attributes;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Base Contract for an Infrastructure Service to
    ///     to manage access to an Azure KeyVault.
    /// </summary>
    [TitleDescription(
        "Azure KeyVault Service",
    "Service to store - securely - keys to 3rd party services (Host Settings (eg: 'appSettings') is only appropriate for configuration settings (eg: srv Account name), not configuration secrets (eg: passwords).",
    "Access to the KeyVault is granted to the App's Service Account at deployment."
    )]
    public interface IAzureKeyVaultService : IRemoteServiceClientInfrastructureService, IAzureService
    {
        /// <summary>
        ///     Gets or sets the standard key divider character ('-').
        ///     <para>
        ///         Whereas AppHost keys can contain ':', etc. -- KeyVault cannot, so
        ///         they must be converted to this character (eg: '-', or '_', or maybe even '')
        ///     </para>
        /// </summary>
        string CleanKeyName(string key);

        /// <summary>
        ///     ???
        /// </summary>
        /// <param name="secretKey">The secret key.</param>
        /// <param name="vaultUrl">The vault URL.</param>
        /// <returns></returns>
        Task<JsonWebKey> RetrieveKeyAsync(string secretKey, string vaultUrl = null);

        /// <summary>
        ///     Retrieves the secret given a key.
        /// </summary>
        /// <param name="secretKey">The secret key.</param>
        /// <param name="vaultUrl">The vault URL.</param>
        /// <returns></returns>
        Task<string> RetrieveSecretAsync(string secretKey, string vaultUrl = null);

        /// <summary>
        ///     Sets a secret.
        /// </summary>
        /// <param name="secretKey">The secret key.</param>
        /// <param name="secret">The secret.</param>
        /// <param name="vaultUrl">The vault URL.</param>
        /// <returns></returns>
        Task<SecretBundle> SetSecretAsync(string secretKey, string secret, string vaultUrl);

        /// <summary>
        ///     Gets the secrets.
        /// </summary>
        /// <param name="returnFQIdentifier">if set to <c>true</c> [return fq identifier].</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="keyVaultUrl">The key vault URL.</param>
        /// <returns></returns>
        Task<IDictionary<string, string>> GetSecretsAsync(bool returnFQIdentifier = false, int pageSize = 0,
            string keyVaultUrl = null);

        /// <summary>
        ///     Lists the secrets keys.
        /// </summary>
        /// <param name="returnFQIdentifier">if set to <c>true</c> [return fq identifier].</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="keyVaultUrl">The key vault URL.</param>
        /// <returns></returns>
        Task<string[]> ListSecretKeysAsync(bool returnFQIdentifier = false, int pageSize = 0,
            string keyVaultUrl = null);


    }
}
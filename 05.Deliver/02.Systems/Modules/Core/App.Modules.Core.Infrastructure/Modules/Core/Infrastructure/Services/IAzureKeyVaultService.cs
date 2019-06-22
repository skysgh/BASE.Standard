// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;
using System.Threading.Tasks;
using App.Modules.All.Infrastructure.Services;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Base Contract for an Infrastructure Service to
    ///     to manage access to an Azure KeyVault.
    /// </summary>
    public interface IAzureKeyVaultService : IInfrastructureService, IAzureService
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


        /// <summary>
        ///     Create a Configuration object and fill properties from KeyVault Secrets with the same name.
        ///     <para>
        ///         Note that default values are not provided if the property value = default(T)
        ///     </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefix">The prefix.</param>
        /// <param name="keyVaultUrl">The key vault URL.</param>
        /// <returns></returns>
        T GetObject<T>(string prefix = null, string keyVaultUrl = null) where T : class;
    }
}
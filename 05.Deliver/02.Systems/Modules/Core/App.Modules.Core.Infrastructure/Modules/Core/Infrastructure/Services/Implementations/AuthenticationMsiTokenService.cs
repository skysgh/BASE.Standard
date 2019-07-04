// Copyright MachineBrains, Inc. 2019

using System.Threading.Tasks;
using App.Modules.All.Infrastructure.Services;
using Microsoft.Azure.Services.AppAuthentication;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IAuthenticationMsiTokenService" />
    ///     Infrastructure Service Contract
    ///     <para>
    ///         The Token can be used to access KeyVault, Databases and other
    ///         Azure services that have been made MSI compatible.
    ///     </para>
    ///     <para>
    ///         When working with a Dev station, the token is built around the
    ///         developer's choice of Identities (usually one that has been associated
    ///         to the target Org's AD). When working in the cloud, the identity
    ///         will be automatically developed when the AppService was first installed.
    ///     </para>
    /// </summary>
    /// <seealso cref="AppCoreServiceBase" />
    /// <seealso cref="IAuthenticationMsiTokenService" />
    public class AuthenticationMsiTokenService : AppCoreServiceBase, IAuthenticationMsiTokenService
    {
        private readonly AzureServiceTokenProvider _azureServiceTokenProvider;

        public AuthenticationMsiTokenService()
        {
            // The constructor is pretty heavy, so prefer to 
            // do it only once:
            _azureServiceTokenProvider = new AzureServiceTokenProvider();
        }

        public string GetToken()
        {
            // Blocking:
            return GetTokenAsync().Result;
        }

        public async Task<string> GetTokenAsync()
        {
            // This will only work if:
            // a) Using Visual Studio 17.5 or higher
            // b) Visual Studio has https://marketplace.visualstudio.com/items?itemName=chrismann.MicrosoftVisualStudioAsalExtension extension installed and VS is restarted.
            // c) You have defined your
            var accessToken = await _azureServiceTokenProvider.GetAccessTokenAsync("https://management.azure.com/")
                .ConfigureAwait(false);

            return accessToken;
        }
    }
}
// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Modules.All.Infrastructure.Helpers;
using App.Modules.Core.Infrastructure.Factories;
using App.Modules.Core.Infrastructure.Services.Caches.Implementations;
using App.Modules.Core.Infrastructure.Services.Configuration.Implementations.AzureConfiguration;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;
using App.Modules.Core.Infrastructure.Services.Statuses;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Rest.Azure;

namespace App.Modules.Core.Infrastructure.Services.Implementations.AzureServices
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IAzureKeyVaultService" />
    ///     Infrastructure Service Contract.
    ///     <para>
    ///         Application's that use Azure KeyVault are hosted in Azure.
    ///         Within Azure Application Registration, when registered, they get an Id.
    ///         Which is automatically mapped to a Service Principal Name (SPN)
    ///         (New-AzureRmADServicePrincipal -ApplicationId {Guid} is invoked behind the scene)
    ///         (and for now think of it as a Psuedo User that this not visible in AAD Users).
    ///         Then within KeyVault, access is granted to the SPN.
    ///         When you sign in, you're using the AppClientId and AppSecret over a secure line.
    ///         That's how Azure recognizes the app (as an SPN, not a proper User or Service Account).
    ///         And hence why the App is given acces to the KeyVault to retrieve secrets and keys.
    ///     </para>
    ///     <para>
    ///         Depends on:
    ///         Nuget:
    ///         * Microsoft.Azure.KeyVault
    ///         * Microsoft.IdentityModel.Clients.ActiveDirectory
    ///         * NOTE: Which relieas on ADAL, as oposed to the newer MSAL...
    ///         * PowerShell:
    ///         * No longer needed: New-AzureRmADServicePrincipal -ApplicationId {Guid}
    ///     </para>
    /// </summary>
    public class AzureKeyVaultService : AppCoreServiceBase, IAzureKeyVaultService
    {
        private readonly AzureKeyVaultServiceConfigurationStatus _configurationStatus;
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IHostSettingsService _hostSettingsService;

        private readonly string _keyVaultUrl;

        // The max number is surprisingly low:
        private readonly int _maxKeysRetrieved = 25;

        private KeyVaultConfigurationObjectFactory _configurationObjectFactory;
        private KeyVaultClient _keyVaultClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureKeyVaultService" /> class.
        /// </summary>
        /// <param name="azureKeyVaultServiceConfiguration">The azure key vault service configuration.</param>
        /// <param name="configurationStatus">The configuration status.</param>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="hostSettingsService">The host settings service.</param>
        public AzureKeyVaultService(
            AzureKeyVaultServiceConfiguration azureKeyVaultServiceConfiguration,
            AzureKeyVaultServiceConfigurationStatus configurationStatus,
            IDiagnosticsTracingService diagnosticsTracingService,
            IHostSettingsService hostSettingsService)
        {
            Configuration = azureKeyVaultServiceConfiguration;
            this._configurationStatus = configurationStatus;
            _diagnosticsTracingService = diagnosticsTracingService;
            _hostSettingsService = hostSettingsService;

            // Not sure if the Url should be in the config object. Probably should...
            _keyVaultUrl = $"https://{Configuration.ResourceName}.vault.azure.net";
        }


        /// <summary>
        ///     Gets the configuration object for this service.
        /// </summary>
        public AzureKeyVaultServiceConfiguration Configuration { get; }

        // One of the very few objects not created by Dependency Injection.
        // Lazy...but I can't think of how else to solve it right now:
        private KeyVaultConfigurationObjectFactory ConfigurationObjectFactory =>
            _configurationObjectFactory ?? (_configurationObjectFactory =
                new KeyVaultConfigurationObjectFactory(_diagnosticsTracingService, this));


        /// <summary>
        ///     Gets the key vault client.
        ///     <para>
        ///         Note that this is just an authenticated client.
        ///         It is not associated to a specific keyvault
        ///         (you need to provide that when you request a key).
        ///     </para>
        /// </summary>
        private KeyVaultClient KeyVaultClient
        {
            get
            {
                if (_keyVaultClient != null)
                {
                    return _keyVaultClient;
                }

                using (var elapsedTime = new ElapsedTime())
                {
                    _diagnosticsTracingService.Trace(TraceLevel.Verbose,
                        "Beginning getting MSI Token...(40 secs not atypical...)");


                    //Are we running in MSI or not?

                    //string msiEndpoint = Environment.GetEnvironmentVariable("MSI_ENDPOINT");
                    //string msiSecret = Environment.GetEnvironmentVariable("MSI_SECRET");
                    //if ((!string.IsNullOrEmpty(msiEndpoint))&& (!string.IsNullOrEmpty(msiSecret)))
                    //{

                    var azureServiceTokenProvider =
                        new AzureServiceTokenProvider();
                    //string accessToken = azureServiceTokenProvider.GetAccessTokenAsync("https://management.azure.com/").Result;
                    //OR
                    _keyVaultClient =
                        new KeyVaultClient(
                            new KeyVaultClient.AuthenticationCallback(
                                azureServiceTokenProvider
                                    .KeyVaultTokenCallback));
                    //}

                    ////Not running in MSI, so return based on ClientId or Secret:
                    //this._keyVaultClient = new KeyVaultClientFactory().Build(
                    //           new ClientCredential(
                    //               this._azureKeyVaultServiceConfiguration.AADClientInfo.ClientId,
                    //               this._azureKeyVaultServiceConfiguration.AADClientInfo.ClientSecret));

                    //return this._keyVaultClient;

                    var msg =
                        $"Took {elapsedTime.ElapsedText} to get an MSI token to build a KeyVaultClient.";

                    _diagnosticsTracingService.Trace(TraceLevel.Verbose, msg);


                    var color = ConfigurationStepStatus.White;
                    if (elapsedTime.Elapsed.TotalMilliseconds > 5000)
                    {
                        color = ConfigurationStepStatus.Orange;
                    }

                    if (elapsedTime.Elapsed.TotalMilliseconds > 10000)
                    {
                        color = ConfigurationStepStatus.Red;
                    }

                    _configurationStatus.AddStep(
                        ConfigurationStepType.General,
                        color,
                        "Authentication",
                        $"Obtaining an Azure MSI Token. Took {elapsedTime.ElapsedText}."
                    );

                return _keyVaultClient;
                }
            }
        }

        /// <summary>
        ///     Applications that use a key vault must authenticate by using a token from Azure Active Directory.
        ///     The application must first register the application in their Azure Active Directory,
        ///     get the ApplicationId and AuthenticationKey (the shared secret).
        ///     clientID and clientSecret are obtained by registering
        ///     the application in Azure AD
        /// </summary>
        /// <param name="secretKey">The secret key.</param>
        /// <param name="keyVaultUrl">The key vault URL.</param>
        /// <returns></returns>
        public async Task<JsonWebKey> RetrieveKeyAsync(string secretKey, string keyVaultUrl = null)
        {
            secretKey = CleanKeyName(secretKey);

            if (string.IsNullOrWhiteSpace(keyVaultUrl))
            {
                keyVaultUrl = _keyVaultUrl;
            }

            var keyBundle = await KeyVaultClient.GetKeyAsync(keyVaultUrl, secretKey);

            return keyBundle.Key;
        }

        /// <summary>
        ///     Retrieves the secret.
        /// </summary>
        /// <param name="secretKey">The secret key.</param>
        /// <param name="keyVaultUrl">The key vault URL.</param>
        /// <returns></returns>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<string> RetrieveSecretAsync(string secretKey, string keyVaultUrl = null)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            secretKey = CleanKeyName(secretKey);

            if (string.IsNullOrWhiteSpace(keyVaultUrl))
            {
                keyVaultUrl = _keyVaultUrl;
            }

            try
            {
                var secret = Task.Run(() => KeyVaultClient.GetSecretAsync(keyVaultUrl, secretKey)).Result;
                return secret.Value;
            }
            catch (Exception e)
            {
                _diagnosticsTracingService.Trace(TraceLevel.Warn,
                    $"KeyVault Secret '{secretKey}' not found. Reason given: '{e.Message}'");
                throw;
            }
        }


        /// <summary>
        ///     Sets the secret.
        /// </summary>
        /// <param name="secretKey">The secret key.</param>
        /// <param name="secret">The secret.</param>
        /// <param name="keyVaultUrl">The key vault URL.</param>
        /// <returns></returns>
        public async Task<SecretBundle> SetSecretAsync(string secretKey, string secret, string keyVaultUrl = null)
        {
            secretKey = CleanKeyName(secretKey);

            if (string.IsNullOrWhiteSpace(keyVaultUrl))
            {
                keyVaultUrl = _keyVaultUrl;
            }

            var secrectBundle = await KeyVaultClient.SetSecretAsync(keyVaultUrl, secretKey, secret);

            return secrectBundle;
        }

        /// <summary>
        ///     Gets the secrets.
        /// </summary>
        /// <param name="returnFQIdentifier">if set to <c>true</c> [return fq identifier].</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="keyVaultUrl">The key vault URL.</param>
        /// <returns></returns>
        public async Task<IDictionary<string, string>> GetSecretsAsync(bool returnFQIdentifier = false,
            int pageSize = 0, string keyVaultUrl = null)
        {
            if (string.IsNullOrWhiteSpace(keyVaultUrl))
            {
                keyVaultUrl = _keyVaultUrl;
            }

            //More than this and you get an error:
            if (pageSize == 0)
            {
                pageSize = _maxKeysRetrieved;
            }

            IPage<SecretItem> secrets = await KeyVaultClient.GetSecretsAsync(keyVaultUrl, pageSize);
            //return this.KeyVaultClient.GetSecretsAsync(keyVaultUrl, 500).GetAwaiter().GetResult().Select(x=>x.Id).ToArray();

            //    KeyValuePair<string> 
            //var x = new Tuple<string, string>("a","b;");

            Dictionary<string, string> results =
                new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);


            foreach (var x in secrets)
            {
                var key = returnFQIdentifier ? x.Identifier.Name : x.Id;
                var value = await RetrieveSecretAsync(x.Identifier.Name);
                results[key] = value;
            }

            return results;
        }


        /// <summary>
        ///     Lists the secrets keys.
        /// </summary>
        /// <param name="returnFQIdentifier">if set to <c>true</c> [return fq identifier].</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="keyVaultUrl">The key vault URL.</param>
        /// <returns></returns>
        public async Task<string[]> ListSecretKeysAsync(bool returnFQIdentifier = false, int pageSize = 0,
            string keyVaultUrl = null)
        {
            if (string.IsNullOrWhiteSpace(keyVaultUrl))
            {
                keyVaultUrl = _keyVaultUrl;
            }

            //More than this and you get an error:
            if (pageSize == 0)
            {
                pageSize = _maxKeysRetrieved;
            }

            IPage<SecretItem> secrets = await KeyVaultClient.GetSecretsAsync(keyVaultUrl, pageSize);

            string[] results = returnFQIdentifier
                ? secrets.Select(x => x.Identifier.Name).ToArray()
                : secrets.Select(x => x.Id).ToArray();

            return results;
        }


        /// <summary>
        ///     Create a Configuration object and fill properties from KeyVault Secrets with the same name.
        ///     <para>
        ///         Note that default values are not provided if the property value = default(T)
        ///     </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefix"></param>
        /// <param name="keyVaultUrl"></param>
        /// <returns></returns>
        public T GetObject<T>(string prefix = null, string keyVaultUrl = null) where T : class
        {
            if (string.IsNullOrWhiteSpace(keyVaultUrl))
            {
                keyVaultUrl = _keyVaultUrl;
            }


            // Build a unique Key to see if the object has already been created
            // and stored in cache.
            var key = typeof(T).FullName + ":" + prefix;


            // Call the KeyVault specific cache:
            if (KeyVaultServiceConfigurationObjectCache.ObjectCache.ContainsKey(key))
            {
                return (T) KeyVaultServiceConfigurationObjectCache.ObjectCache[key];
            }

            using (var elapsedTime = new ElapsedTime())
            {
                // If not, instead of making one here, 
                // start with an object that has been processed by the HostSettings.
                var result = _hostSettingsService.GetObject<T>(prefix);

                // And override any values with KeyValues
                ConfigurationObjectFactory.Provision(result, prefix);

                // Then cache it:
                HostSettingsServiceConfigurationObjectCache.ObjectCache[key] = result;

                var msg =
                    $"Took {elapsedTime.ElapsedText} to build and provision the {result.GetType()} configuration object (using KeyVault/AppHost settings).";

                _diagnosticsTracingService.Trace(TraceLevel.Verbose, msg);
                return result;
            }
        }

        //public void Do()
        //{

        //    //Get the storage key as a secret in KeyVault
        //    var storageKey = await GetStorageKey();
        //    string storageAccountName = ConfigurationManager.AppSettings["storageAccountName"];
        //    var creds = new StorageCredentials(storageAccountName, storageKey);
        //    var storageAccount = new CloudStorageAccount(creds, true);
        //    var queueClient = storageAccount.CreateCloudQueueClient();
        //    var queue = queueClient.GetQueueReference("samplequeue");
        //    await queue.CreateIfNotExistsAsync();
        //    await queue.AddMessageAsync(new CloudQueueMessage("Hello keyvault"));

        //}


        /// <summary>
        ///     Gets or sets the standard key divider character ('-').
        ///     <para>
        ///         Whereas AppHost keys can contain ':', etc. -- KeyVault cannot, so
        ///         they must be converted to this character (eg: '-', or '_', or maybe even '')
        ///     </para>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string CleanKeyName(string key)
        {
            foreach (var k in Configuration.KeyIllegalCharacters)
            {
                key = key.Replace(k, Configuration.KeyStandardNameComponentDivider);
            }

            return key;
        }
    }
}
using App.Modules.All.Shared.Constants;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace App
{
    public static class IConfigurationBuilderExtensionMethods
    {

        public static void AddKeyVaultSettingsConfig(this IConfigurationBuilder config, bool enabled=true)
        {

            var builtConfig = config.Build();

            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient = new KeyVaultClient(
                new KeyVaultClient.AuthenticationCallback(
                    azureServiceTokenProvider.KeyVaultTokenCallback));
            var defaultKeyVaultSecretManager = new DefaultKeyVaultSecretManager();

            if (!enabled)
            {
                return;
            }

            string keyVaultName = builtConfig[Storage.KeyVaultName];
            if (keyVaultName.StartsWith("TODO:"))
            {
                return;
            }

            config.AddAzureKeyVault(
                $"https://{keyVaultName}.vault.azure.net/",
                keyVaultClient,
                defaultKeyVaultSecretManager 
                );
        }
    }
}

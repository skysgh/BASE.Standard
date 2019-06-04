using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace App.Modules.Core.Infrastructure.ExtensionMethods
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

            string keyVaultName = builtConfig[App.Modules.Core.Shared.Constants.Application.KeyVaultName];
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

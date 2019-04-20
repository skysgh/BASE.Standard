namespace App.Modules.Core.Shared.Constants
{
    public class AppModuleApiScopes
    {
        public const string ServiceUrl = App.Modules.Core.Shared.Constants.ConfigurationKeys.SystemIntegrationKeyPrefix
                                         + Core.Shared.Constants.ConfigurationKeys.SystemModuleApiScopeServiceUrl;


        public const string ReadScope = "core_read";
        public const string WriteScope = "core_write";
    }
}





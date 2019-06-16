namespace App.Modules.Core.Shared.Constants
{
    /// <summary>
    /// TODO
    /// </summary>
    public class ModuleSpecificApiScopes
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public const string ServiceUrl = App.Modules.Core.Shared.Constants.ConfigurationKeys.SystemIntegrationKeyPrefix
                                         + Core.Shared.Constants.ConfigurationKeys.SystemModuleApiScopeServiceUrl;


        public const string ReadScope = "core_read";
        public const string WriteScope = "core_write";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}





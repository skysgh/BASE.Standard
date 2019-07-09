using Microsoft.Extensions.Configuration;

namespace App
{
    public static class IConfigurationExtensions
    {
        public static TConfigurationObject Get<TConfigurationObject>(this IConfiguration configuration)
        {
            var result = System.Activator.CreateInstance<TConfigurationObject>();
            configuration.Get(result);
            return result;
        }

        public static void Get<TConfigurationObject>(this IConfiguration configuration, TConfigurationObject target)
        {
            string moduleName =
                typeof(TConfigurationObject).GetModuleIdentifier();

            string[] suffixes = new string[]
            {
                "",
                "ServiceConfigurationSettings",
                "ConfigurationSettings",
                "ServiceConfiguration",
                "Settings",
                "Configuration"
            };

            foreach (string suffix in suffixes)
            {

                string configName = typeof(TConfigurationObject).Name;

                if ((!suffix.IsNullOrEmpty())
                    &&
                    (configName.Length > suffix.Length))
                {
                    configName =
                        configName.Substring(0,
                            configName.Length - suffix.Length);
                }
                string sectionName = $"app:modules:{moduleName}:{configName}";

                if (!configuration.GetSection(sectionName).Exists())
                {
                    continue;
                }

                configuration.Bind(sectionName, target);
                return;
            }
        }

    }
}

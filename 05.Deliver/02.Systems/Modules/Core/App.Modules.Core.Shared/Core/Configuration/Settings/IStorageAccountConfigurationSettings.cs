namespace App.Modules.Core.Configuration.Settings
{
    public interface IStorageAccountConfigurationSettings
    {
        string ResourceName { get; set; }
        string ResourceNameSuffix { get; set; }
        string Key { get; set; }
    }
}
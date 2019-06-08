namespace App.Modules.Core.Shared.Configuration.Settings
{
    public interface IStorageAccountConfigurationSettings
    {
        string ResourceName { get; set; }
        string ResourceNameSuffix { get; set; }
        string Key { get; set; }
    }
}
namespace App.Modules.Core.Shared.Configuration.Settings
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public interface IStorageAccountConfigurationSettings
    {
        string ResourceName { get; set; }
        string ResourceNameSuffix { get; set; }
        string Key { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
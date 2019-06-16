namespace App.Modules.Core.Shared.Models.Entities
{
    // TODO: Enums are evil (offset issue of Interface Localization)
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public enum NotificationType
    {
        Undefined,
        Notification,
        Message,
        Task
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
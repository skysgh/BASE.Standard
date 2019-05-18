namespace App.Modules.Core.Shared.Models
{
    public interface IHasSerializedTypeValue
    {
        string SerializedTypeName { get; set; }
        string SerializedTypeValue { get; set; }
    }
}
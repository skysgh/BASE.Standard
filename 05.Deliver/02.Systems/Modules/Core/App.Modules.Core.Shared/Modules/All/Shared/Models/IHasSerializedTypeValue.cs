namespace App.Modules.All.Shared.Models
{
    public interface IHasSerializedTypeValue
    {
        string SerializedTypeName { get; set; }
        string SerializedTypeValue { get; set; }
    }
}
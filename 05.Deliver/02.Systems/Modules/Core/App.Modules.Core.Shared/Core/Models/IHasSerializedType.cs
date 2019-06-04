namespace App.Modules.Core.Models
{
    public interface IHasSerializedTypeValue
    {
        string SerializedTypeName { get; set; }
        string SerializedTypeValue { get; set; }
    }
}
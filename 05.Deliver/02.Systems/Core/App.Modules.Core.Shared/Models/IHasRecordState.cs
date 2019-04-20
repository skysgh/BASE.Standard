namespace App.Modules.Core.Shared.Models
{
    using App.Modules.Core.Shared.Models.Entities;

    public interface IHasRecordState
    {
        RecordPersistenceState RecordState { get; set; }
    }
}
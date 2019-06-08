
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.All.Shared.Models
{
    public interface IHasRecordState
    {
        RecordPersistenceState RecordState { get; set; }
    }
}
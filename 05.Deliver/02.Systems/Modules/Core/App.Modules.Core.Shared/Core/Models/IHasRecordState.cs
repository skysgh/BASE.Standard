
using App.Modules.Core.Models.Entities;

namespace App.Modules.Core.Models
{
    public interface IHasRecordState
    {
        RecordPersistenceState RecordState { get; set; }
    }
}
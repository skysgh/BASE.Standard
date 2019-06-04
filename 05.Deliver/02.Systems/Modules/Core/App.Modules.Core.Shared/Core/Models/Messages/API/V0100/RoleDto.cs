using System;
using App.Modules.Core.Models.Entities;

namespace App.Modules.Core.Models.Messages.API.V0100
{
    public class RoleDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasRecordState
    {
        public virtual Guid Id
        {
            get; set;
        }

        public string ModuleKey { get; set; }

        public virtual RecordPersistenceState RecordState
        {
            get; set;
        }

        public virtual bool Enabled
        {
            get; set;
        }


        public virtual string Key
        {
            get; set;
        }
        public DataClassificationDto DataClassification
        {
            get; set;
        }


    }
}
using System;
using App.Modules.Core.Factories;
using App.Modules.Core.Models.Entities;

namespace App.Modules.Core.Models.Messages
{
    public abstract class TenantedRecordStateGuidIdReferenceDtoBase  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : TenantedRecordStateGuidIdDtoBase
    {
        protected TenantedRecordStateGuidIdReferenceDtoBase(): base()
        {
            //this.Id = GuidFactory.NewGuid();
        }

        public virtual string Text { get; set; }
    }


    public abstract class TenantedRecordStateGuidIdDtoBase : /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ TenantedRecordStatedDtoBase, IHasGuidId
    {
        protected TenantedRecordStateGuidIdDtoBase()
        {
            this.Id = GuidFactory.NewGuid();
        }

        public virtual Guid Id
        {
            get; set;
        }
    }

    public abstract class TenantedRecordStatedDtoBase : /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ IHasTenantFK, IHasRecordState
    {
        public virtual RecordPersistenceState RecordState
        {
            get; set;
        }

        public virtual Guid TenantFK
        {
            get; set;
        }
    }

}

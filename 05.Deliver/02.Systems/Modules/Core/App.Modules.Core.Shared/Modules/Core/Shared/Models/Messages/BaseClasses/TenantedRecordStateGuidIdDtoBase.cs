using System;
using App.Modules.All.Shared.Factories;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages
{
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
}
namespace App.Modules.Core.Shared.Models.Messages
{
    public abstract class TenantedRecordStateGuidIdReferenceDtoBase  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : TenantedRecordStateGuidIdDtoBase
    {
        protected TenantedRecordStateGuidIdReferenceDtoBase(): base()
        {
            //this.Id = GuidFactory.NewGuid();
        }

        public virtual string Text { get; set; }
    }
}

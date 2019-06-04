﻿namespace App.Modules.Core.Models.Messages.API.V0100
{
    public class SearchResponseItemDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */  //: IHasGuidId, IHasRecordState
    {
        public virtual string SourceTypeKey { get; set; }

        //[Key]
        public virtual string SourceIdentifier { get; set; }

        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string ImageUrl { get; set; }
    }
}
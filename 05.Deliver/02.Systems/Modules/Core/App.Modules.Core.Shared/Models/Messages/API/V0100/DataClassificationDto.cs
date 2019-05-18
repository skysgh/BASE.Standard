﻿namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    using System;
    using App.Modules.Core.Shared.Models.Entities;

    [Serializable]
    public class DataClassificationDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ 
    {
        public virtual NZDataClassification Id { get; set; }    
        public virtual bool Enabled { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual int DisplayOrderHint { get; set; }
        public virtual string DisplayStyleHint { get; set; }
    }


}

using System;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// Background:
    /// As per https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration
    /// </summary>
    public class PrincipalTagAssignment : UntenantedRecordStatedTimestampedNoIdEntityBase
    {

        public Guid PrincipalFK { get; set; }
        public Principal Principal {get;set;}

        public Guid TagFK { get; set; }
        public PrincipalTag Tag { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Shared.Models.Entities
{
    using App.Modules.Core.Shared.Factories;

    public class IdentityProvider : IHasGuidId, IHasTimestamp, IHasRecordState
    {
        public IdentityProvider()
        {
            GuidFactory.NewGuid();
        }

        public Guid Id { get; set; }
        public byte[] Timestamp { get; set; }
        public RecordPersistenceState RecordState { get; set; }

        public string Key { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
    }
}

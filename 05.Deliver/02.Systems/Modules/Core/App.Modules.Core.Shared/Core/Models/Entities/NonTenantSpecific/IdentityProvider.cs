using System;
using App.Modules.Core.Factories;

namespace App.Modules.Core.Models.Entities
{
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

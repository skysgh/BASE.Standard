using System;
using App.Modules.All.Shared.Factories;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Entities
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

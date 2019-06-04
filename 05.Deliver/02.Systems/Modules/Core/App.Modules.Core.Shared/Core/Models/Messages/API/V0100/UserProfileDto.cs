using System;

namespace App.Modules.Core.Models.Messages.API.V0100
{
    public class UserProfileDto : IHasGuidId
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string DisplayName { get; set; }
    }
}

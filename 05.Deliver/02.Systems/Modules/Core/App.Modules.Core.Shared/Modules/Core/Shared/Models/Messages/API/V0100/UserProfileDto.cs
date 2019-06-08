using System;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    public class UserProfileDto : IHasGuidId
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string DisplayName { get; set; }
    }
}

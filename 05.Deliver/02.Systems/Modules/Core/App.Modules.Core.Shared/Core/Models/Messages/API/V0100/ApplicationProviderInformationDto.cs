using System;

namespace App.Modules.Core.Models.Messages.API.V0100
{
    public class ApplicationProviderInformationDto
    {
        public Guid Id {
            get; set;
        }

        public string Name
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public string SiteUrl { get; set; }
        public string ContactUrl
        {
            get; set;
        }
    }
}
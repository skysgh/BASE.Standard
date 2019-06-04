using System;

namespace App.Modules.Core.Models.Messages.API.V0100
{
    /// <summary>
    /// DTO Message for <see cref="ApplicationDescriptionConfigurationSettings"/>
    /// summarizing the Application's Name, Description, Creator, Distributor.
    /// For use by any User Agent to render on their Header View.
    /// </summary>
    /// <seealso cref="IHasGuidId" />
    public class ApplicationDescriptionDto : IHasGuidId
    {
        public Guid Id
        {
            get; set;
        }


        public string Name { get; set; }

        public string Description
        {
            get; set;
        }

        public ApplicationProviderInformationDto Creator { get; set; }

        public ApplicationProviderInformationDto Distributor 
        {
            get; set;
        }
    }
}

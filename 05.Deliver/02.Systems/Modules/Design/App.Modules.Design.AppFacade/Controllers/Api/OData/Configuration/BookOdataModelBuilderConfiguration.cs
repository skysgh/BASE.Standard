using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Design.Shared.Models.Entities;

namespace App.Modules.Design.AppFacade.Controllers.Api.OData.Configuration
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class BookOdataModelBuilderConfiguration : ModuleGuidIdODataModelBuilderConfigurationBase<Book>
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ExceptionRecordOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IModuleOdataModelBuilderConfiguration"/> won't find them.
        /// </internal>
        public BookOdataModelBuilderConfiguration() : base()
        {

        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}



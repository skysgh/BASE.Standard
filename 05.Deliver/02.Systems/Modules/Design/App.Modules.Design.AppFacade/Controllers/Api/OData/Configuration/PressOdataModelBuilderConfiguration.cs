using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Design.Shared.Models.Entities;

namespace App.Modules.Design.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Press" />
    public class PressOdataModelBuilderConfiguration : ModuleGuidIdODataModelBuilderConfigurationBase<Press>
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ExceptionRecordOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IModuleOdataModelBuilderConfiguration"/> won't find them.
        /// </internal>
        public PressOdataModelBuilderConfiguration() : base()
        {

        }
    }

}



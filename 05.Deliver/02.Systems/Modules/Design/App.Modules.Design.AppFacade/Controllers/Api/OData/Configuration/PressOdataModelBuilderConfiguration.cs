using App.Modules.Core.Controllers.Api.OData.Configuration;
using App.Modules.Core.Controllers.Api.OData.Configuration.Base;
using App.Modules.Design.Shared.Models.Entities;

namespace App.Modules.Design.AppFacade.Controllers.Api.OData.Configuration
{
    public class PressOdataModelBuilderConfiguration : AllModulesGuidIdODataModelBuilderConfigurationBase<Press>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionRecordOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IAllModulesOdataModelBuilderConfiguration"/> won't find them.
        /// </internal>
        public PressOdataModelBuilderConfiguration() : base()
        {

        }
    }

}



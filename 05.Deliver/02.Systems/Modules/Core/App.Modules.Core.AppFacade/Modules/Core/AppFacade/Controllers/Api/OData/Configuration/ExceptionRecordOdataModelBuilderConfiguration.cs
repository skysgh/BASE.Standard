using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Shared.Models.Messages.API.V0100;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{

    public class ExceptionRecordOdataModelBuilderConfiguration

        : AllModulesGuidIdODataModelBuilderConfigurationBase<ExceptionRecordDto>
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ExceptionRecordOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IAllModulesOdataModelBuilderConfiguration"/> won't find them.
        /// </internal>
        public ExceptionRecordOdataModelBuilderConfiguration() : base()
        {

        }
    }


}
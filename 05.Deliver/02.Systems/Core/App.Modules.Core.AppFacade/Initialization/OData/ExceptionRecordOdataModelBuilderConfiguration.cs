
using App.Modules.Core.AppFacade.Initialization.OData;
using App.Modules.Core.AppFacade.Initialization.OData.Base;
using App.Modules.Core.Shared.Models.Messages.API.V0100;

namespace App.Core.Application.Initialization.OData.Implementations
{

    public class ExceptionRecordOdataModelBuilderConfiguration : AppCoreODataModelBuilderConfigurationBase<ExceptionRecordDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionRecordOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IAppCoreOdataModelBuilderConfiguration"/> won't find them.
        /// </internal>
        public ExceptionRecordOdataModelBuilderConfiguration() : base()
        {

        }
    }


}
﻿using App.Modules.Core.AppFacade.Initialization.OData.Base;
using App.Modules.Core.Shared.Models.Messages.API.V0100;

namespace App.Modules.Core.AppFacade.Initialization.OData.Implementations
{
    public class RequirementOdataModelBuilderConfiguration : ModuleODataModelBuilderConfigurationBase<RequirementDto>
    {
    }

    public class ExceptionRecordOdataModelBuilderConfiguration : ModuleODataModelBuilderConfigurationBase<ExceptionRecordDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionRecordOdataModelBuilderConfiguration"/> class.
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
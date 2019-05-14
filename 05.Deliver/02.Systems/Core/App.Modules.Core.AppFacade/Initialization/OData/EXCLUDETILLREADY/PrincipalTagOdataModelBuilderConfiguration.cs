﻿namespace App.Core.Application.Initialization.OData.Implementations
{
    using App.Core.Application.Constants.Api;
    using App.Core.Shared.Models.Messages.API.V0100;

    public class PrincipalTagOdataModelBuilderConfiguration : AppCoreODataModelBuilderConfigurationBase<PrincipalTagDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrincipalTagOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IOdataModelBuilderConfigurationBase"/> won't find them.
        /// </internal>
        public PrincipalTagOdataModelBuilderConfiguration() : base(ApiControllerNames.PrincipalTag)
        {

        }
    }


}

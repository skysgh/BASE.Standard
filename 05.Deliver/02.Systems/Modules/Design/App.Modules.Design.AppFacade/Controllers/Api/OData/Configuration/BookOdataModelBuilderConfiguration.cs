﻿using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Design.Shared.Models.Entities;

namespace App.Modules.Design.AppFacade.Controllers.Api.OData.Configuration
{
    public class BookOdataModelBuilderConfiguration : AllModulesGuidIdODataModelBuilderConfigurationBase<Book>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionRecordOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IAllModulesOdataModelBuilderConfiguration"/> won't find them.
        /// </internal>
        public BookOdataModelBuilderConfiguration() : base()
        {

        }
    }

}



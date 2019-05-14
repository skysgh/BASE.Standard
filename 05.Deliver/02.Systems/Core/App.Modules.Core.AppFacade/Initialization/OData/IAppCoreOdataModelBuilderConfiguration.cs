using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.OData.Builder;

namespace App.Modules.Core.AppFacade.Initialization.OData
{
    public interface IAppCoreOdataModelBuilderConfiguration : IModelConfiguration
    {
        //void Apply(ODataModelBuilder builder, ApiVersion apiVersion);
    }
}

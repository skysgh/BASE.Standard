using Microsoft.AspNet.OData.Builder;

namespace App.Modules.Core.Controllers.Api.OData.Configuration
{


    public interface IAllModulesOdataModelBuilderConfiguration : 
        IModelConfiguration
    {
        //void Apply(ODataConventionModelBuilder builder, ApiVersion apiVersion);
    }
}

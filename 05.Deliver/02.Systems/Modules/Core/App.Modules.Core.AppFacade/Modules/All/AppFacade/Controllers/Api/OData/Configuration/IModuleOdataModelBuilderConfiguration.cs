using Microsoft.AspNet.OData.Builder;

namespace App.Modules.All.AppFacade.Controllers.Api.OData.Configuration
{

    /// <summary>
    /// Contract for all OData ModelBuilder Configuration
    /// objects.
    /// <para>
    /// Objects that derive from this interface
    /// (in most cases by being a subclass of
    /// <see cref="ModuleODataModelBuilderConfigurationBase{T}"/>)
    /// are found by reflection at startup.
    /// </para>
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.OData.Builder.IModelConfiguration" />
    public interface IModuleOdataModelBuilderConfiguration : 
        IModelConfiguration
    {
        //void Apply(ODataConventionModelBuilder builder, ApiVersion apiVersion);
    }
}

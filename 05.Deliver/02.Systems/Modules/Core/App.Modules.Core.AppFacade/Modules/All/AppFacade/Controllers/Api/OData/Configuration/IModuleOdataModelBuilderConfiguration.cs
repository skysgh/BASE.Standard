// Copyright MachineBrains, Inc. 2019

using App.Modules.All.AppFacade.DependencyResolution;
using Microsoft.AspNet.OData.Builder;

namespace App.Modules.All.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    ///     Contract for all OData ModelBuilder Configuration
    ///     objects.
    ///     <para>
    ///         Objects that derive from this interface
    ///         (in most cases by being a subclass of
    ///         <see cref="ModuleGuidIdODataModelBuilderConfigurationBase{T}" />,
    ///         and rarely from <see cref="ModuleODataModelBuilderConfigurationBase{T}" />)
    ///         are found by reflection at startup
    ///         (see <see cref="AllModulesAppFacadeServiceRegistry" />).
    ///     </para>
    ///     <para>
    ///         Tip: if the DTO does not have a Guid Id property,
    ///         derive from the base class and define your own Id
    ///         (all OData entities have to have one property designated
    ///         as the <c>Key</c> property).
    ///     </para>
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.OData.Builder.IModelConfiguration" />
    public interface IModuleOdataModelBuilderConfiguration :
        IModelConfiguration
    {
        //void Apply(ODataConventionModelBuilder builder, ApiVersion apiVersion);
    }
}
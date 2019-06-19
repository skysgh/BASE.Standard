using App.Modules.All.Shared.Models;
using Microsoft.AspNet.OData.Builder;

namespace App.Modules.All.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    /// Module Specific
    /// OData Model Definition.
    /// <para>
    /// Describes the specified DTO,
    /// and the Controller
    /// from which to retrieve it.
    /// </para>
    /// <para>
    /// Invoked by a Model Builder
    /// during Startup.
    /// </para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="App.Modules.All.AppFacade.Controllers.Api.OData.Configuration.ModuleODataModelBuilderConfigurationBase{T}" />
    public abstract class ModuleGuidIdODataModelBuilderConfigurationBase<T> : 
        ModuleODataModelBuilderConfigurationBase<T>
        where T : class, IHasGuidId, new()
    {
        /// <summary>
        /// Defines the EntityTypeConfiguration for the given Type.
        /// <para>
        /// Note that the key is set to the property called Id.
        /// </para>
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public override EntityTypeConfiguration<T> Define(ODataModelBuilder builder)
        {
            var entity = base.Define(builder);

            entity.HasKey(x => x.Id);

            return entity;
        }

    }
}
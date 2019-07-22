// Copyright MachineBrains, Inc. 2019

using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Shared.Models.DTOs;
using Microsoft.AspNet.OData.Builder;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    ///     An OData Configuration object to define the shape of an
    ///     <see cref="ApplicationDescriptionDto" />, and relate it to a Controller.
    /// </summary>
    /// <seealso cref="ModuleGuidIdODataModelBuilderConfigurationBase{T}" />
    public class ApplicationDescriptionOdataModelBuilderConfiguration
        : ModuleODataModelBuilderConfigurationBase<ApplicationDescriptionDto>
    {
        /// <summary>
        ///     Defines the entity set for T.
        ///     <para>
        ///         Note that the Key is not set (it is up to a subclass to define which
        ///         property of the DTO is the Key).
        ///     </para>
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public override EntityTypeConfiguration<ApplicationDescriptionDto> Define(ODataModelBuilder builder)
        {
            var entityTypeConfiguration = base.Define(builder);

            entityTypeConfiguration.HasKey(x => x.Key);
            return entityTypeConfiguration;

        }
    }
}
// Copyright MachineBrains, Inc. 2019

using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Infrastructure.Services.Statuses;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using Microsoft.AspNet.OData.Builder;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    ///     An OData Configuration object to define the shape of an
    ///     <see cref="SessionDto" />, and relate it to a Controller.
    ///     <para>
    ///     </para>
    /// </summary>
    /// <seealso cref="ModuleGuidIdODataModelBuilderConfigurationBase{T}" />
    public class ConfigurationStatusComponentOdataModelBuilderConfiguration
        : ModuleODataModelBuilderConfigurationBase<ConfigurationStatusComponentDto>
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
        public override EntityTypeConfiguration<ConfigurationStatusComponentDto> Define(ODataModelBuilder builder)
        {

            string check = this.ControllerName;
            var entityType = base.Define(builder);
            entityType.HasKey(x=>x.Title);
            return entityType;
        }
    }
}
// Copyright MachineBrains, Inc. 2019

using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using Microsoft.AspNet.OData.Builder;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    ///     An OData Configuration object to define the shape of an
    ///     <see cref="EmailDto" />, and relate it to a Controller.
    /// </summary>
    /// <seealso
    ///     cref="App.Modules.All.AppFacade.Controllers.Api.OData.Configuration.ModuleODataModelBuilderConfigurationBase{EmailDto}" />
    public class EmailODataModelBuilderConfiguration : ModuleODataModelBuilderConfigurationBase<EmailDto>
    {
        /// <summary>
        ///     Defines the entity set for T.
        ///     <para>
        ///         Note that the key is set to the property called Id.
        ///     </para>
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public override EntityTypeConfiguration<EmailDto> Define(ODataModelBuilder builder)
        {
            EntityTypeConfiguration<EmailDto> entity = base.Define(builder);
            entity.HasKey(x => x.To);

            return entity;
        }
    }
}
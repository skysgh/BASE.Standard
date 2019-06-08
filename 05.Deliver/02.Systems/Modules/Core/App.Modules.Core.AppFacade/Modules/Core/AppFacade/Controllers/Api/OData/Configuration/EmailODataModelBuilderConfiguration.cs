﻿using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using Microsoft.AspNet.OData.Builder;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    public class EmailODataModelBuilderConfiguration : AllModulesODataModelBuilderConfigurationBase<EmailDto>
    {

        public override EntityTypeConfiguration<EmailDto> Define(ODataModelBuilder builder)
        {
            var entity = base.Define(builder);
            entity.HasKey(x => x.To);

            return entity;
        }
    }
}
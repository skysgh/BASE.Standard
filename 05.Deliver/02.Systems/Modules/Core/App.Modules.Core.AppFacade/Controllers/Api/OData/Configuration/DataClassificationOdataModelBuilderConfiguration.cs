using App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Models.Messages.API.V0100;
using Microsoft.AspNet.OData.Builder;

namespace App.Core.Application.Initialization.OData.Implementations
{
    public class DataClassificationOdataModelBuilderConfiguration
        : AllModulesODataModelBuilderConfigurationBase<DataClassificationDto>
    {
        public override EntityTypeConfiguration<DataClassificationDto> Define(ODataModelBuilder builder)
        {
            var r = base.Define(builder);

            var a = r.Action("Get");
            a.Parameter<string>("key");
            a.Returns<int>();

            a = r.Action("Fuzz");
            a.Parameter<string>("key");
            a.Returns<int>();


            return r;
        }

        //public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        //{
        //    switch (apiVersion.MajorVersion)
        //    {
        //        case 2:
        //            ConfigureV2(builder);
        //            break;
        //        default:
        //            ConfigureV1(builder);
        //            break;
        //    }
        //}
        //private void ConfigureV1(ODataModelBuilder builder)
        //{
        //    var entity = Define(builder);
        //    //entity.Ignore(p => p.ExtraField);
        //}

        //private void ConfigureV2(ODataModelBuilder builder)
        //{
        //    Define(builder);
        //}
    }
}
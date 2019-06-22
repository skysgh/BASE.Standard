// Copyright MachineBrains, Inc. 2019

using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using Microsoft.AspNet.OData.Builder;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    ///     Configuration object to describe the DTO and the Controller from which to retrieve it.
    /// </summary>
    /// <seealso cref="ModuleODataModelBuilderConfigurationBase{T}" />
    public class DataClassificationOdataModelBuilderConfiguration
        : ModuleODataModelBuilderConfigurationBase<DataClassificationDto>
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
        public override EntityTypeConfiguration<DataClassificationDto> Define(ODataModelBuilder builder)
        {
            EntityTypeConfiguration<DataClassificationDto> r = base.Define(builder);

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
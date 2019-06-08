//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.OData.Edm;

//namespace App.Core.Application.Initialization.OData.Implementations
//{
//    /// <summary>
//    /// Implementation invoked at Statup, when building 
//    /// OData Models.
//    /// I don't necessarily agree with this,
//    /// A class to get all the modules and tie it together to an api route 
//    /// </summary>
//    public class AppOdataAllModelBuilder : IOdataModelBuilder
//    {
//        public IEnumerable<IEdmModel> GetEdmModels(HttpConfiguration configuration)
//        {
//            var modelBuilder = new VersionedODataModelBuilder(configuration)
//            {
//                ModelBuilderFactory = () => new ODataConventionModelBuilder(),
//                ModelConfigurations =
//                {
//                    //new ApplicationDescriptionOdataModelBuilderConfiguration(),
//                    //new DataClassificationOdataModelBuilderConfiguration(),

//                }
//            };
//            foreach (var item in RegisterByReflectionTheODataModelDefinitions())
//            {
//                modelBuilder.ModelConfigurations.Add(item);
//            }

//            return modelBuilder.GetEdmModels();
//        }

//        public string GetRoutePrefix()
//        {
//            return "all";
//        }


//        private IModelConfiguration[] RegisterByReflectionTheODataModelDefinitions()
//        {
//            return AppDependencyLocator.Current.GetAllInstances<IModelConfiguration>().ToArray();
//        }
//    }
//}

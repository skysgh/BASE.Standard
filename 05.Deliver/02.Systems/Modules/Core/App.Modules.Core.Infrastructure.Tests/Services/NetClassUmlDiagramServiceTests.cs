//using System;
//using System.Collections.Generic;
//using System.Text;
//using App.Modules.Core.Infrastructure.Services;
//using App.Modules.Core.Infrastructure.Services.Implementations;
//using App.Modules.Core.Infrastructure.Tests.TestData;
//using Xunit;

//namespace App.Modules.Core.Infrastructure.Tests.Services
//{
//    public class NetClassUmlDiagramServiceTests : TestClassBase
//    {

//        [Fact]
//        public void Can_Retrieve_Service()
//        {

//            var service =
//                DependencyLocator.Current
//                    .GetInstance<INetClassPlantUmlDiagramService>();

//            Xunit.Assert.NotNull(service);

//        }

//        [Fact]
//        public void Can_Describe_Type()
//        {
//            var service =
//                DependencyLocator.Current
//                    .GetInstance<INetClassPlantUmlDiagramService>();

//            service.Document(typeof(TestObjectB).FullName);

//            Xunit.Assert.NotNull(service);

//        }
//    }
//}

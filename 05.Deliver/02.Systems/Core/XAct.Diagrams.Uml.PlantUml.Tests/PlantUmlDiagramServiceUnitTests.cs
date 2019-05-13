namespace XAct.Diagrams.Uml.Tests
{
    using System;
    using NUnit.Framework;
    using XAct;
    using XAct.Diagrams.Uml.Services.Implemtations;
    using XAct.Tests;

    /// <summary>
    ///   NUNit Test Fixture.
    /// </summary>
    [TestFixture(Description = "Some Fixture")]
    public class PlantUmlDiagramServiceUnitTests
    {
        /// <summary>
        ///   Sets up to do before any tests 
        ///   within this test fixture are run.
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            //run once before any tests in this testfixture have been run...
            //...setup vars common to all the upcoming tests...

            Singleton<IocContext>.Instance.ResetIoC();

        }

        /// <summary>
        ///   Tear down after all tests in this fixture.
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            //IoCBootStrapper.Instance =null;
        }

        [TearDown]
        public void MyTestTearDown()
        {
            GC.Collect();
        }


        ///// <summary>
        /////   An Example Test.
        ///// </summary>
        //[Test(Description = "")]
        //public void UnitTest01()
        //{
        //    SOMECLASSNAME ctrl = new SOMECLASSNAME();
        //    Assert.IsTrue(true);
        //}


        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Get_PlantUmlDiagramService()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<IPlantUmlDiagramService>();

            Assert.IsNotNull(service);
        }

        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Get_PlantUmlDiagramService_Of_Expected_Type()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<IPlantUmlDiagramService>();

            Assert.AreEqual(typeof (PlantUmlDiagramService), service.GetType());
        }

        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Get_PlantUmlDiagramService_Configuration()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<IPlantUmlDiagramService>();


            Assert.IsNotNull(service.Configuration);
            Assert.IsNotNullOrEmpty(service.Configuration.ServerUrl);
            Assert.IsNotNullOrEmpty(service.Configuration.Format);
        }

        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Serialize_UML_Image()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<IPlantUmlDiagramService>();

            string uml =
                @"interface IFoo {
-- Properties --
+ int : Count {get;set;}
+ Current : Bar {get;set;}
-- Methods --
+Clear();
}

class Foo  {

}
class Bar {
 + int Id {get;set;}
 + string Name {get;set;}
}

IFoo <|.. Foo

";

            string result = service.SerializeUml(uml);
            Console.WriteLine(result);

            Assert.IsNotNullOrEmpty(result);
        }

        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Develop_Url_For_Image()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<IPlantUmlDiagramService>();

            string uml =
                @"interface IFoo {
-- Properties --
+ int : Count {get;set;}
+ Current : Bar {get;set;}
-- Methods --
+Clear();
}

class Foo  {

}
class Bar {
 + int Id {get;set;}
 + string Name {get;set;}
}

IFoo <|.. Foo

";

            string url = service.DevelopImageUrl(uml);

            Console.WriteLine(url);
            Assert.IsNotNullOrEmpty(url);
            Assert.IsTrue(url.StartsWith("http"));
            Assert.IsTrue(url.Contains(service.Configuration.ServerUrl));
            Assert.IsTrue(url.Contains(service.Configuration.Format));
        }
    }


}



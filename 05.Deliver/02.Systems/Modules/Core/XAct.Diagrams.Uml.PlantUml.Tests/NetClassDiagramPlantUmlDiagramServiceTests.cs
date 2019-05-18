using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace XAct.Diagrams.Uml.Tests
{
    using XAct.Diagnostics.Implementations;
    using XAct.Diagrams.Uml.Services.Implemtations;
    using XAct.Services.Comm.ServiceModel.Services.Implementations;
    using XAct.Tests;
    using XAct.Users;


    [TestFixture]
    public class NetClassDiagramPlantUmlDiagramServiceTests
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


        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Get_NetClassDiagramPlantUmlDiagramService()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            Assert.IsNotNull(service);
        }

        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Get_PlantUmlDiagramService_Of_Expected_Type()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            Assert.AreEqual(typeof(NetClassDiagramPlantUmlDiagramService), service.GetType());
        }


        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_A_Class_With_No_Packaging_As_Uml()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            string uml =
                service.DocumentType(new RenderingStats(typeof (CachedWcfServiceAgentService)));

            Console.WriteLine(uml);

            Assert.IsTrue(uml.Contains("CachedWcfServiceAgentService\" {"));
            Assert.IsTrue(uml.Contains(".XActLibServiceBase\" {"));
            Assert.IsTrue(
                uml.Contains(
                    "+ Query<TService, TResult>(Func<TService, TResult> func, String cacheKey, Nullable<TimeSpan> cacheTimeSpan, Boolean bypassCaching, Boolean forceUpdateOfCache) : TResult"));
        }

        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_A_Class_Within_No_Packaging_As_An_Url()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            string url = service.DocumentTypeAsImageUrl(new RenderingStats(typeof(CachedWcfServiceAgentService)));

            Console.WriteLine(url);

            Assert.IsTrue(url.Contains("http://www.plantuml.com/plantuml/"));
        }

        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_A_Class_With_No_Packaging_As_An_Url2()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            string url = service.DocumentTypeAsImageUrl(new RenderingStats(typeof(SystemDiagnosticsTracingService)));

            Console.WriteLine(url);

            Assert.IsTrue(url.Contains("http://www.plantuml.com/plantuml/"));
        }



        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_A_Class_With_Packaging_By_Assembly_As_Uml()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            string uml = service.DocumentType(new RenderingStats(typeof(CachedWcfServiceAgentService), PackageRenderingType.Assembly));

            Console.WriteLine(uml);

            Assert.IsTrue(uml.Contains("CachedWcfServiceAgentService\" {"));
            Assert.IsTrue(uml.Contains(".XActLibServiceBase\" {"));
            Assert.IsTrue(uml.Contains("+ Query<TService, TResult>(Func<TService, TResult> func, String cacheKey, Nullable<TimeSpan> cacheTimeSpan, Boolean bypassCaching, Boolean forceUpdateOfCache) : TResult"));
        }
    
        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_A_Class_With_Packaging_By_Assembly_As_Uml2()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            string uml = service.DocumentType(new RenderingStats(typeof(SystemDiagnosticsTracingService), PackageRenderingType.Assembly));

            Console.WriteLine(uml);

            Assert.IsTrue(uml.Contains("SystemDiagnosticsTracingService\" {"));
            Assert.IsTrue(uml.Contains("+ DebugTrace(Int32 stackTraceFrameOffset, TraceLevel traceLevel, String message, Object[] arguments) : Void"));
        }


        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_A_Class_With_Packaging_By_Assembly_As_An_Image()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            string url = service.DocumentTypeAsImageUrl(new RenderingStats(typeof(CachedWcfServiceAgentService), PackageRenderingType.Assembly));

            Console.WriteLine(url);

            Assert.IsTrue(url.Contains("http://www.plantuml.com/plantuml/"));
        }



        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_A_Class_With_Packaging_By_Assembly_As_An_Image2()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            string url = service.DocumentTypeAsImageUrl(new RenderingStats(typeof(SystemDiagnosticsTracingService), PackageRenderingType.Assembly));

            Console.WriteLine(url);

            Assert.IsTrue(url.Contains("http://www.plantuml.com/plantuml/"));
        }

        

        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_A_Class_With_Packaging_By_Namespace_As_Uml()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            string uml = service.DocumentType(new RenderingStats(typeof(CachedWcfServiceAgentService), PackageRenderingType.Namespace));

            Console.WriteLine(uml);


            Assert.IsTrue(uml.Contains("CachedWcfServiceAgentService\" {"));
            Assert.IsTrue(uml.Contains(".XActLibServiceBase\" {"));
            Assert.IsTrue(uml.Contains("+ Query<TService, TResult>(Func<TService, TResult> func, String cacheKey, Nullable<TimeSpan> cacheTimeSpan, Boolean bypassCaching, Boolean forceUpdateOfCache) : TResult"));
        }


        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_A_Class_With_Packaging_By_Namespace_As_Uml2()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            string uml = service.DocumentType(new RenderingStats(typeof(CachedWcfServiceAgentService), PackageRenderingType.Namespace));

            Console.WriteLine(uml);

            Assert.IsTrue(uml.Contains("CachedWcfServiceAgentService\" {"));
            Assert.IsTrue(uml.Contains(".XActLibServiceBase\" {"));
            Assert.IsTrue(uml.Contains("+ Query<TService, TResult>(Func<TService, TResult> func, String cacheKey, Nullable<TimeSpan> cacheTimeSpan, Boolean bypassCaching, Boolean forceUpdateOfCache) : TResult"));
        }





        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_A_Class_With_Packaging_By_Namespace_As_An_Image()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            string url = service.DocumentTypeAsImageUrl(new RenderingStats(typeof(CachedWcfServiceAgentService), PackageRenderingType.Namespace));

            Console.WriteLine(url);

            Assert.IsTrue(url.Contains("http://www.plantuml.com/plantuml/"));
        }



        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_A_Class_With_Packaging_By_Namespace_As_An_Image2()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            string url = service.DocumentTypeAsImageUrl(new RenderingStats(typeof(SystemDiagnosticsTracingService), PackageRenderingType.Namespace));

            Console.WriteLine(url);

            Assert.IsTrue(url.Contains("http://www.plantuml.com/plantuml/"));
        }

        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_Several_Classes_With_No_Packagin_As_An_Image()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            Type[] stopAt = new[] { typeof(IHasDistributedGuidIdAndTimestamp), typeof(IHasEnabled), typeof(IHasAuditability) };

            string url = service.DocumentTypeAsImageUrl(
                new RenderingStats(
                    new []{typeof(User), typeof(UserProperty), typeof(UserClaim)},
                    PackageRenderingType.None, 
                    stopAt));

            Console.WriteLine(url);

            Assert.IsTrue(url.Contains("http://www.plantuml.com/plantuml/"));
        }
        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_Several_Classes_With_Packaging_By_None_As_An_Image_StoppingAt_Some_Types()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            Type[] stopAt = new Type[]
                {
                    typeof(IHasDistributedGuidIdAndTimestamp), 
                    typeof(IHasEnabled), 
                    typeof(IHasAuditability),
                    typeof(IHasDateTimeCreatedBy),
                    typeof(IHasDateTimeModifiedBy),
                    typeof(IHasSerializedTypeValueAndMethod),
                    typeof(IHasKey)
                };

            string url = service.DocumentTypeAsImageUrl(
                new RenderingStats(
                    new[] { typeof(User), typeof(UserProperty), typeof(UserClaim) },
                    PackageRenderingType.None,
                    stopAt
                    ));

            Console.WriteLine(url);

            Assert.IsTrue(url.Contains("http://www.plantuml.com/plantuml/"));
        }


        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_Several_Classes_With_Packaging_By_Namespace_As_An_Image_StoppingAt_Some_Types()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            Type[] stopAt = new Type[]
                {
                    typeof(IHasDistributedGuidIdAndTimestamp), 
                    typeof(IHasEnabled), 
                    typeof(IHasAuditability),
                    typeof(IHasDateTimeCreatedBy),
                    typeof(IHasDateTimeModifiedBy),
                    typeof(IHasSerializedTypeValueAndMethod),
                    typeof(IHasKey)
                };

            string url = service.DocumentTypeAsImageUrl(
                new RenderingStats(
                    new[] { typeof(User), typeof(UserProperty), typeof(UserClaim) }, 
                    PackageRenderingType.Namespace,
                    stopAt 
                    ));

            Console.WriteLine(url);

            Assert.IsTrue(url.Contains("http://www.plantuml.com/plantuml/"));
        }





        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_A_Class_With_Packaging_By_Assembly_As_An_Image_While_StoppingAt()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();


            string url = service.DocumentTypeAsImageUrl(
                new RenderingStats(
                    types :new[] {typeof (User)},
                    packageRenderingType: PackageRenderingType.Assembly,
                    stopAt: new[]
                        {
                            typeof (IHasDistributedGuidIdAndTimestamp),
                            typeof (IHasEnabled),
                            typeof (IHasAuditability),
                            typeof (IHasDateTimeCreatedBy),
                            typeof (IHasDateTimeModifiedBy),
                            typeof (IHasSerializedTypeValueAndMethod),
                            typeof (IHasKey)
                        }
                    ));

            Console.WriteLine(url);


            Assert.IsTrue(url.Contains("http://www.plantuml.com/plantuml/"));
        }


        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_A_Class_With_Packaging_By_Assembly_As_An_Url_While_StoppingAt()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();


            string uml = service.DocumentType(
                new RenderingStats(
                    types: new[] { typeof(User) },
                    packageRenderingType: PackageRenderingType.Assembly,
                    stopAt: new[]
                        {
                            typeof (IHasDistributedGuidIdAndTimestamp),
                            typeof (IHasEnabled),
                            typeof (IHasAuditability),
                            typeof (IHasDateTimeCreatedBy),
                            typeof (IHasDateTimeModifiedBy),
                            typeof (IHasSerializedTypeValueAndMethod),
                            typeof (IHasKey)
                        }
                    ));

            Console.WriteLine(uml);


            Assert.IsTrue(uml.Contains("Property Relationships:"));
        }


        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_Several_Classes_With_Packaging_By_None_As_An_Image()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            Type[] stopAt = new[]
                {
                    typeof(IHasDistributedGuidIdAndTimestamp), 
                    typeof(IHasEnabled), 
                    typeof(IHasAuditability),
                    typeof(IHasDateTimeCreatedBy),
                    typeof(IHasDateTimeModifiedBy),
                    typeof(IHasSerializedTypeValueAndMethod),
                    typeof(IHasKey)
                };

            string url = service.DocumentTypeAsImageUrl(
                new RenderingStats(
                    new[] { typeof(User), typeof(UserProperty), typeof(UserClaim) },
                    PackageRenderingType.None,
                    stopAt
                    ));

            Console.WriteLine(url);

            Assert.IsTrue(url.Contains("http://www.plantuml.com/plantuml/"));
        }


        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_Several_Classes_With_Packaging_By_Assembly_As_An_Image()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            Type[] stopAt = new[]
                {
                    typeof(IHasDistributedGuidIdAndTimestamp), 
                    typeof(IHasEnabled), 
                    typeof(IHasAuditability),
                    typeof(IHasDateTimeCreatedBy),
                    typeof(IHasDateTimeModifiedBy),
                    typeof(IHasSerializedTypeValueAndMethod),
                    typeof(IHasKey)
                };

            string url = service.DocumentTypeAsImageUrl(
                new RenderingStats(
                    new[] { typeof(User), typeof(UserProperty), typeof(UserClaim) }, 
                    PackageRenderingType.Assembly, 
                    stopAt
                    ));

            Console.WriteLine(url);

            Assert.IsTrue(url.Contains("http://www.plantuml.com/plantuml/"));
        }

        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_Several_Classes_With_Packaging_By_Namespace_As_Uml()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            Type[] stopAt = new[]
                {
                    typeof(IHasDistributedGuidIdAndTimestamp), 
                    typeof(IHasEnabled), 
                    typeof(IHasAuditability),
                    typeof(IHasDateTimeCreatedBy),
                    typeof(IHasDateTimeModifiedBy),
                    typeof(IHasSerializedTypeValueAndMethod),
                    typeof(IHasKey)
                };

            string url = service.DocumentType(
                new RenderingStats(
                    new[] { typeof(User), typeof(UserProperty), typeof(UserClaim) },
                    PackageRenderingType.Namespace,
                    stopAt
                    ));

            Console.WriteLine(url);

            Assert.That(url.Contains("class \"XAct.Users.UserClaim\" {"), Is.True, "Should have class definition...");
            Assert.That(url.Contains("\"XAct.Users.UserClaim\" ..> \"XAct.SerializationMethod\""),Is.True,"Should have dependency on SerializationMethod");
        }


        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_Several_Classes_With_Packaging_By_Assembly2_As_An_Image()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            Type[] stopAt = new Type[]
                {
                    typeof(IHasDistributedGuidIdAndTimestamp), 
                    typeof(IHasEnabled), 
                    typeof(IHasAuditability),
                    typeof(IHasDateTimeCreatedBy),
                    typeof(IHasDateTimeModifiedBy),
                    typeof(IHasSerializedTypeValueAndMethod),
                    typeof(IHasKey)
                };

            string url = service.DocumentTypeAsImageUrl(
                new RenderingStats(
                    new[] { typeof(User), typeof(UserProperty), typeof(UserClaim) },
                    PackageRenderingType.Assembly,
                    stopAt
                    ));

            Console.WriteLine(url);

            Assert.IsTrue(url.Contains("http://www.plantuml.com/plantuml/"));
        }



        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_Several_Classes_With_Packaging_By_Namespace_As_An_Image_Foobar()
        {
            var service = XAct.DependencyResolver.Current.GetInstance<INetClassDiagramPlantUmlDiagramService>();

            Type[] stopAt = new Type[]
                {
                    typeof(IHasDistributedGuidIdAndTimestamp), 
                    typeof(IHasEnabled), 
                    typeof(IHasAuditability),
                    typeof(IHasDateTimeCreatedBy),
                    typeof(IHasDateTimeModifiedBy),
                    typeof(IHasSerializedTypeValueAndMethod),
                    typeof(IHasKey)
                };

            string url = service.DocumentTypeAsImageUrl(
                new RenderingStats(
                    new[] { typeof(User) , typeof(UserProperty), typeof(UserClaim)},
                    PackageRenderingType.Assembly,
                    stopAt
                    ));

            Console.WriteLine(url);

            Assert.IsTrue(url.Contains("http://www.plantuml.com/plantuml/"));
        }





    }
}

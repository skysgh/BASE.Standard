using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAct.Diagrams.Uml.Tests
{
    using System.Diagnostics;
    using System.Reflection;
    using NUnit.Framework;
    using XAct.Collections;
    using XAct.Services.Comm.ServiceModel.Services.Implementations;
    using XAct.Tests;

    [TestFixture]
    public class ClassDiagramTests
    {

        #region 
        public interface IDemoClass
        {
            int PublicProp { get; set; }
            void PublicMethod();
            List<int>[] PublicMethod(Dictionary<int, string> stuff);
        }

        public abstract class DemoClassBase : IDemoClass
        {
            public abstract int PublicProp { get; set; }
            public abstract void PublicMethod();

            public abstract List<int>[] PublicMethod(Dictionary<int, string> stuff);
        }


        public class DemoClass : DemoClassBase
        {
            public DemoClass(){}
            protected DemoClass(int i){}
            internal DemoClass(int i, string s, char c) { }



            override public int PublicProp { get; set; }
            internal string InternalProp { get; private set; }
            protected char ProtectedProp { private get; set; }
            private char PrivateProp { get; set; }

            override public void PublicMethod(){}
            override public List<int>[] PublicMethod(Dictionary<int, string> stuff) { return null; }
            internal int InternalMethod<T>(IList<Dictionary<int, string>> x) { return 0; }
            protected string ProtectedMethod<T>(string first,int age){return ".";}
            private string[] PrivateMethod<T>(string first, int age){return new[]{"A","B"};}
        }

        #endregion


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
        public void Can_Build_Class_Of_Properties()
        {
            var classDiagram = new ClassDiagram();
            classDiagram.Title = "SomeClass";
            classDiagram.AddProperty(new EntityDiagramProperty(EntityDiagramMemberVisibility.Public, "string",
                                                               "SomePublicProp", true));
            classDiagram.AddProperty(new EntityDiagramProperty(EntityDiagramMemberVisibility.Private, "int",
                                                               "SomePrivateProp", false));

            var result = classDiagram.ToString();

            Console.Write(result);

            Assert.IsTrue(result.Contains("+ SomePublicProp"));
            Assert.IsTrue(result.Contains("- SomePrivateProp"));
        }


        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Build_Class_Of_Properties_And_Methods()
        {
            var classDiagram = new ClassDiagram();
            classDiagram.Title = "SomeClass";
            classDiagram.AddProperty(new EntityDiagramProperty(EntityDiagramMemberVisibility.Public, "string",
                                                               "SomePublicProp", true));
            classDiagram.AddProperty(new EntityDiagramProperty(EntityDiagramMemberVisibility.Private, "int",
                                                               "SomePrivateProp", false));

            classDiagram.AddMethod(EntityDiagramMemberVisibility.Public, "string", "SomePublicMethod",null,null);
            classDiagram.AddMethod(EntityDiagramMemberVisibility.Internal, "int", "SomeInternalMethod", null, new EntityDiagramMethodArgument[] { new EntityDiagramMethodArgument("string", "A"), new EntityDiagramMethodArgument("string", "B"), });
            classDiagram.AddMethod(EntityDiagramMemberVisibility.Protected, "bool", "SomeProtectedMethod", null, new EntityDiagramMethodArgument[] { new EntityDiagramMethodArgument(typeof(int), "A"), new EntityDiagramMethodArgument(typeof(string), "B"), });
            classDiagram.AddMethod(EntityDiagramMemberVisibility.Private, "char", "SomePrivateMethod", new[]{"T","T2"}, null);

            var result = classDiagram.ToString();

            Console.Write(result);

            Assert.IsTrue(result.Contains("+ SomePublicMethod"));
            Assert.IsTrue(result.Contains("- SomePrivateMethod"));
        }

        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Describe_Class()
        {
            
            var classDiagram = new ClassDiagram();
            classDiagram.CreateFrom(typeof (DemoClass));

            var result = classDiagram.ToString();
            Console.Write(result);

            Assert.IsTrue(result.Contains("+ PublicMethod"));
            Assert.IsTrue(result.Contains("- PrivateMethod"));
        }

        [Test]
        public void Convert_PropertInfo()
        {
            var type = typeof (DemoClass);
            var mi = type.GetMethod("InternalMethod",BindingFlags.Instance|BindingFlags.NonPublic);
            Assert.IsNotNull(mi);

            var md = mi.MapTo();

            Assert.IsNotNull(md);

            var result = md.ToString();
            Console.WriteLine(result);

            Assert.That(result.Contains("~ InternalMethod"), "1");
            Assert.That(result.Contains("Dictionary<Int32, String>"), "2");
            Assert.That(result.Contains("IList<Dictionary<Int32, String>>"), "3");
            Assert.That(result.Contains(": Int32"),"4");


        }

        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Convert_Generic_Type_To_Readable_String()
        {
            var x = new Dictionary<int, List<string>>();

            string result = x.GetType().GetName(false);
            Console.WriteLine(result);
        }




        [Test]
        public void DescribeType()
        {
            var t = typeof (DemoClass);

            var constructor = t.GetConstructorWithMostArguments(BindingFlags.Instance | BindingFlags.Public);

            List<TreeNode<Type>> results = new List<TreeNode<Type>>();

            results.Add(t.GetInterfaceInheritence());

            foreach (var parameter in constructor.GetParameters())
            {
                if (parameter.ParameterType.IsValueType)
                {
                    continue;
                }
                results.Add(parameter.ParameterType.GetInterfaceInheritence());
            }


        }

    }
}

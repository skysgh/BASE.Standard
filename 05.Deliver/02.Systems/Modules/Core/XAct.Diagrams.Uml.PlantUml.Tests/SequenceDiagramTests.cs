using System;

namespace XAct.Diagrams.Uml.Tests
{
    using NUnit.Framework;
    using XAct.Tests;

    [TestFixture]
    public class SequenceDiagramTests
    {

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
        public void Can_Get_SequenceDiagram_Title()
        {
            var sequenceDiagram = new SequenceDiagram();

            sequenceDiagram.SetTitle("Test");

            var output = sequenceDiagram.ToString();
            //Visually inspect:
            Console.WriteLine(output);

            Assert.IsTrue(output.Contains("title Test"));
        }


        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Get_SequenceDiagram_Comment()
        {
            var sequenceDiagram = new SequenceDiagram();

            sequenceDiagram
                .SetTitle("Test")
                .AddComment("This is a comment.");


            var output = sequenceDiagram.ToString();
            //Visually inspect:
            Console.WriteLine(output);

            Assert.IsTrue(output.Contains("'This is a comment."));
        }

        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Get_SequenceDiagram_Sequence()
        {
            var sequenceDiagram = new SequenceDiagram();

            sequenceDiagram
                .SetTitle("Test")
                .AddComment("This is a comment.")
                .AddSequence("A", "B", "foo()");

            var output = sequenceDiagram.ToString();
            //Visually inspect:
            Console.WriteLine(output);

            Assert.IsTrue(output.Contains("\"A\" -> \"B\" : \"foo()\""));
        }
        [Test]
        [NUnit.Framework.Category("UML")]
        [NUnit.Framework.Category("Services")]
        [NUnit.Framework.Category("PlantUMLService")]
        public void Can_Get_SequenceDiagram_Group()
        {
            var sequenceDiagram = new SequenceDiagram();

            sequenceDiagram
                .SetTitle("Test")
                .AddComment("This is a comment.")
                .AddSequence("A", "B", "foo()")
                .BeginGroup("some group")
                .AddSequence("B", "C", "foo()")
                .AddSequence("C", "D", "int")
                .EndGroup()
                .AddSequence("E", "F", "bar()")
            .AddSequenceResponse("F", "E", "int");
            
            
            var output = sequenceDiagram.ToString();
            //Visually inspect:
            Console.WriteLine(output);

            Assert.IsTrue(output.Contains("group some group"));
        }

    }
}

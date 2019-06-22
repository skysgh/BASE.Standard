using System.Linq;
using App.Diagrams.PlantUml.Uml;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Common.Tests.Attributes;
using App.Modules.Core.Infrastructure.ObjectMapping.Messages;
using App.Modules.Core.Shared.Models.Entities;
using Xunit;
using FluentAssertions;

namespace App.Modules.Core.Infrastructure.Tests.Extensions
{

 
    public class TypeExtensions : TestClassBase
    {
        internal class TestForConstructorReflection
        {
            public TestForConstructorReflection() { }
            public TestForConstructorReflection(string a, string b) { }
            public TestForConstructorReflection(string a, string b, string c) { }
        }

        [SelfNamingFact()]
        public void GetConstructorWithMostArgumentsWhichIsWhatADependencyInjectorWouldBeLookingFor()
        {
            typeof(TestForConstructorReflection)
                .GetConstructorWithMostArguments().GetParameters().Last() 
                .Name.Should()
                .Be("c");
        }

        [SelfNamingFactAttribute]
        public void DetermineIfTypeImplementsInterface()
        {
            typeof(Principal).ImplementsInterface<IHasGuidId>().Should()
                .Be(true);
        }
        [SelfNamingFactAttribute]
        public void DetermineIfTypeDoesNotImplementsInterface()
        {
            typeof(Principal).ImplementsInterface<IHasLatitudeAndLongitude>().Should()
                .Be(false);
        }
    }
}

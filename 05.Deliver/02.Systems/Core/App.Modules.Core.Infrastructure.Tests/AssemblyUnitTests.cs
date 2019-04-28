using System;
using Xunit;

namespace App.Modules.Core.Infrastructure.Tests
{
    public class AssemblyUnitTests: TestClassBase
    {
        [Fact]
        public void EnsureAssemblyNameIsGeneric()
        {
            Type type = typeof(Infrastructure.Services.IExampleInfrastructureService);

            Assert.True(type.Assembly.GetName().Name.StartsWith(Shared.Constants.Application.AssemblyPrefix),
                "ISO-25010/Portability: ensure assembly names are generic.");
        }

    }
}

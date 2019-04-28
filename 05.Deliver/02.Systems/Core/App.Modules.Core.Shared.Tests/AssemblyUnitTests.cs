using System;
using Xunit;

namespace App.Modules.Core.Shared.Tests
{
    public class AssemblyUnitTests
    {
        [Fact]
        public void EnsureAssemblyNameIsGeneric()
        {
            Type type = typeof(Shared.Models.IHasGuidId);

            Assert.True(type.Assembly.GetName().Name.StartsWith(Shared.Constants.Application.AssemblyPrefix),
                "ISO-25010/Portability: ensure assembly names are generic.");
        }
    }
}

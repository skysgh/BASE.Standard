using System;
using Xunit;

using App;
using App.Modules.Core.Models;

namespace App.Modules.Core.Shared.Tests
{
    public class AssemblyUnitTests
    {
        [Fact]
        public void EnsureAssemblyNameIsGeneric()
        {
            Type type = typeof(IHasGuidId);

            Assert.True(
                type.IsSameApp(),
                "ISO-25010/Portability: ensure assembly names are generic.");
        }
    }
}

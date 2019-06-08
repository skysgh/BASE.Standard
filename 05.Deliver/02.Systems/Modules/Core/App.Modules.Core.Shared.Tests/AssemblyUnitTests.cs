using System;
using Xunit;

using App;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models;

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

using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Common.Tests.Attributes;
using Xunit;

namespace App.Modules.Core.Shared.Tests
{
    public class AssemblyUnitTests
    {
        [SelfNamingFact]
        public void EnsureAssemblyNameIsGeneric()
        {
            Type type = typeof(IHasGuidId);

            Assert.True(
                type.IsSameApp(),
                "ISO-25010/Portability: ensure assembly names are generic.");
        }
    }
}

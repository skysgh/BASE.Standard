using System;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Tests.Attributes;
using Xunit;

namespace App.Modules.Core.Shared.Tests
{
    public class ExampleModelUnitTest
    {
        [SelfNamingFact]
        public void Test1()
        {
            Principal test = new Principal();
            Assert.True(test.Id == Guid.Empty);
        }
    }
}

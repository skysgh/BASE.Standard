using App.Modules.Core.Shared.Models.Implementations;
using System;
using Xunit;

namespace App.Modules.Core.Shared.Tests
{
    public class ExampleModelUnitTest
    {
        [Fact]
        public void Test1()
        {
            ExampleModel test = new ExampleModel();
            Assert.True(test.Id == Guid.Empty);
        }
    }
}

using System;
using Xunit;

namespace App.Modules.Core.Infrastructure.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void EnsureAssemblyNameIsGeneric()
        {
            Type type = typeof(Application.Services.IExampleService);

            Assert.True(type.Assembly.GetName().Name.StartsWith(Shared.Constants.Application.APPPREFIX),
                "ISO-25010/Portability: ensure assembly names are generic.");
        }
    }
}

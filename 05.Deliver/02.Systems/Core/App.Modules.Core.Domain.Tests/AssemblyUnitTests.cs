using System;
using Xunit;

namespace App.Modules.Core.Infrastructure.Tests
{
    public class AssemblyUnitTests
    {
        [Fact]
        public void EnsureAssemblyNameIsGeneric()
        {
            Type type = typeof(Domain.Services.IExampleDomainService);

            Assert.True(type.Assembly.GetName().Name.StartsWith(Shared.Constants.Application.APPPREFIX),
                "ISO-25010/Portability: ensure assembly names are generic.");
        }
    }
}

using System;
using App.Modules.All.Shared.Constants;
using Xunit;

namespace App.Modules.Core.Domain.Tests
{
    public class AssemblyUnitTests
    {
        [Fact]
        public void EnsureAssemblyNameIsGeneric()
        {
            Type type = typeof(Domain.Services.IExampleDomainService);

            //Assert.True(type.IsSameApp(),
            //    "ISO-25010/Portability: ensure assembly names are generic.");
        }

        [Fact]
        public void Architecture_Ensure_Business_Domain_Is_Kept_Completely_Separate_From_Infrastructure_Domain()
        {
            bool found = false;
            foreach (var ra in typeof(Domain.Services.IExampleDomainService).Assembly.GetReferencedAssemblies())
            {
                    
                if (ra.Name == $"{Module.GetAssemblyNamePrefix(this.GetType())}Infrastructure" )
                {
                    found = true;

                    break;
                }
            }
            Assert.False(found);
        }
    }
}

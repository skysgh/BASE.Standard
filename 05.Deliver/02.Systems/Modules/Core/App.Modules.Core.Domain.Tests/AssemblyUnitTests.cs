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

            Assert.True(type.Assembly.GetName().Name.StartsWith(Shared.Constants.Application.AssemblyPrefix),
                "ISO-25010/Portability: ensure assembly names are generic.");
        }

        [Fact]
        public void Architecture_Ensure_Business_Domain_Is_Kept_Completely_Separate_From_Infrastructure_Domain()
        {
            bool found = false;
            foreach (var ra in typeof(Domain.Services.IExampleDomainService).Assembly.GetReferencedAssemblies())
            {
                    
                if (ra.Name == $"{Shared.Constants.Module.AssemblyNamePrefix}Infrastructure" )
                {
                    found = true;

                    break;
                }
            }
            Assert.False(found);
        }
    }
}

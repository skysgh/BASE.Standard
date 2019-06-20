using System;
using App.Modules.Core.Common.Tests.Attributes;
using App.Modules.Core.Shared.Models.Entities;
using Xunit;

namespace App.Modules.Core.Shared.Tests
{
    public class PrincipalModelUnitTests
    {
        [SelfNamingFact]
        public void CanCreatePrincipal()
        {
            Principal test = new Principal();
            // New principals always have an Id:
            Assert.True(test.Id != Guid.Empty);
        }
    }
}

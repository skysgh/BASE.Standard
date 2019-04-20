using App.Modules.Core.Shared.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace App.Modules.Core.Shared.Tests
{
    public class GuidFactoryUnitTests
    {

        [Fact]
        public void CreateGuid() {
            Guid r = GuidFactory.NewGuid();
            Assert.NotEqual<Guid>(Guid.Empty, r);
        }

        [Fact]
        public void CreateSeveralUniqueGuid()
        {
            List<Guid> r = new List<Guid>();
            int m = 1000;
            for (int i = 0; i < m; i++)
            {
                r.Add(GuidFactory.NewGuid());
            }

            for (int i = 0; i < m; i++)
            {
                for (int j=0; j < m; j++)
                {
                    if (i == j) { continue; }
                    Assert.NotEqual<Guid>(r[i], r[j]);
                }
            }
        }

    }
}

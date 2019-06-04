using System;
using System.Collections.Generic;
using App.Modules.Core.Factories;
using Xunit;

namespace App.Modules.Core.Shared.Tests
{
    public class GuidFactoryUnitTests
    {

        [SelfNamingFact]
        public void CreateAGuidUsingTheGuidFactory()
        {
            Guid r = GuidFactory.NewGuid();
            Assert.NotEqual<Guid>(Guid.Empty, r);
        }

        [SelfNamingFact]
        public void Create_A_Thousand_Unique_Guids_Without_Duplication()
        {
            List<Guid> r = new List<Guid>();
            int m = 1000;
            for (int i = 0; i < m; i++)
            {
                r.Add(GuidFactory.NewGuid());
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == j) { continue; }
                    Assert.NotEqual<Guid>(r[i], r[j]);
                }
            }
        }

    }
}

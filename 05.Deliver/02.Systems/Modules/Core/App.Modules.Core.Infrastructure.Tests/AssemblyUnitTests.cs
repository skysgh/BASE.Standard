using System;
using App.Modules.Core.Shared.Constants.All;
using Xunit;
using static App.Modules.Core.Shared.Constants.All.SystemOutcomeTypeTerms.Qualities;

namespace App.Modules.Core.Infrastructure.Tests
{
    public class AssemblyUnitTests : TestClassBase
    {
        [Fact(DisplayName="Ensure AssemblyName Begins With Convention")]
        [Trait(SystemOutcomeTypeTerms.Traits.Quality, SystemOutcomeTypeTerms.Qualities.ISO25010Terms.Portability)]
        public void Ensure_AssemblyName_Begins_With_Convention()
        {
            Type type = typeof(Infrastructure.Services.IExampleInfrastructureService);

            //Assert.True(type.IsSameApp(),
            //    $"{ISO25010Terms.Portability}: ensure assembly names are generic.");
        }

    }

}

using App.Modules.Core.Common.Tests.Attributes;
using App.Modules.Core.Shared.Constants.All;
using FluentAssertions;
using Xunit;

namespace App.Modules.Core.Infrastructure.Tests.Extensions
{

    public class StringExtensions
    {
        [SelfNamingTheory]
        [InlineData("thisIsATest")]
        [InlineData("this_Is_A_Test")]
        [InlineData("this_is_a_test")]
        [InlineData("this_is_A_test")]
        [InlineData("This_isA_test")]
        [InlineData("ThisIsA_Test")]
        [Trait(SystemOutcomeTypeTerms.Traits.Feature, SystemOutcomeTypeTerms.Features.General)]
        public void SplitLowerCamelCaseMethodName(string text)
        {
            var r = text.SplitCamelCase();
            r.Should().Be("This Is A Test");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Shared.Tests;
using Xunit;
using FluentAssertions;
using App.Modules.Core.Shared.Constants.All;

namespace App.Modules.Core.Infrastructure.Tests
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

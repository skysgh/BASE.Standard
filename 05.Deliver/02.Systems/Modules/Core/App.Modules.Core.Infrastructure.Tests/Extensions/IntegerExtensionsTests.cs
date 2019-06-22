using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Common.Tests.Attributes;
using FluentAssertions;

namespace App.Modules.Core.Infrastructure.Tests.Extensions
{
    public class IntegerExtensions : TestClassBase
    {
        [SelfNamingFact]
        public void TestIfBitIsSet()
        {
            17.BitIsSet(1).Should().Be(true);
            17.BitIsSet(16).Should().Be(true);
            //And:
            17.BitIsSet(2).Should().Be(false);
            17.BitIsSet(4).Should().Be(false);
            17.BitIsSet(8).Should().Be(false);
            17.BitIsSet(32).Should().Be(false);
        }

        [SelfNamingFact]
        public void TestIfBitIsNotSet()
        {
            17.BitIsNotSet(2).Should().Be(true);
            17.BitIsNotSet(4).Should().Be(true);
            17.BitIsNotSet(8).Should().Be(true);
            17.BitIsNotSet(32).Should().Be(true);
            //And:
            17.BitIsNotSet(1).Should().Be(false);
            17.BitIsNotSet(16).Should().Be(false);


        }
        [SelfNamingFact]
        public void TestBitClear()
        {
            17.BitClear(1).Should().Be(16);
            17.BitClear(2).Should().Be(17);
            17.BitClear(4).Should().Be(17);
            17.BitClear(8).Should().Be(17);
            17.BitClear(16).Should().Be(1);
            17.BitClear(32).Should().Be(17);


        }

        [SelfNamingFact]
        public void TestBitSet()
        {
            17.BitSet(1).Should().Be(17);
            17.BitSet(2).Should().Be(19);
            17.BitSet(4).Should().Be(21);
            17.BitSet(8).Should().Be(25);
            17.BitSet(16).Should().Be(17);
            17.BitSet(32).Should().Be(49);


        }



    }
}

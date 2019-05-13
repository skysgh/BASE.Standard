using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Infrastructure.Tests.TestData
{
    public interface ITestObj
    {

    }

    public interface ITestObject : ITestObj
    {

    }

    public class TestObjectA : ITestObject
    {
    }

    public class TestObjectB : TestObjectA
    {
    }
}

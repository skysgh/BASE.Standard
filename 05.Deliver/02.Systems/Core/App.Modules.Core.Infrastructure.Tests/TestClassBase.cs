using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Infrastructure.Tests
{
    public abstract class TestClassBase
    {
        protected TestClassBase()
        {
            // Use the common DI setup code 
            // located in the common dll:
            Common.UnitTestDependencyInjectionInitializer.Initialize();

        }
    }
}

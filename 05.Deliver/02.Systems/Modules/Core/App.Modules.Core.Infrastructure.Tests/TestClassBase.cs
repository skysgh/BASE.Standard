using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Common.Tests;

namespace App.Modules.Core.Infrastructure.Tests
{
    public abstract class TestClassBase
    {
        protected TestClassBase()
        {
            // Use the common DI setup code 
            // located in the common dll:
            UnitTestDependencyInjectionInitializer.Initialize();

        }
    }
}

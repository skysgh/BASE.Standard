using System.Runtime.CompilerServices;

namespace App.Modules.Core.Shared.Tests.Attributes
{
    [Xunit.Sdk.XunitTestCaseDiscoverer("Xunit.Sdk.TheoryDiscoverer", "xunit.execution.{Platform}")]
    public class SelfNamingTheoryAttribute : SelfNamingFactAttribute
    {
        public SelfNamingTheoryAttribute([CallerMemberName] string testMethodName = ""):
            base()
        {
        }
    }

}



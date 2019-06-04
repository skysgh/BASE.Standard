using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

namespace App.Modules.Core.Shared.Tests
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



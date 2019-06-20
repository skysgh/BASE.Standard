using System.Runtime.CompilerServices;
using App.Modules.Core.Common.Tests.Attributes;

namespace App.Modules.Core.Common.Tests.Attributes
{
    [Xunit.Sdk.XunitTestCaseDiscoverer("Xunit.Sdk.TheoryDiscoverer", "xunit.execution.{Platform}")]
    public class SelfNamingTheoryAttribute : SelfNamingFactAttribute
    {
        public SelfNamingTheoryAttribute([CallerMemberName] string testMethodName = "") :
            base()
        {
        }
    }

}



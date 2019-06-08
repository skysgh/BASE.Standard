using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

namespace App.Modules.Core.Shared.Tests.Attributes
{

    public class SelfNamingFactAttribute : FactAttribute
    {
        public SelfNamingFactAttribute([CallerMemberName] string testMethodName = "")
        {
            base.DisplayName = SplitOnCapitalLetters(testMethodName);
        }

        static string SplitOnCapitalLetters(string text)
        {
            var result = new StringBuilder();

            char prevChar = (char)0;

            foreach (var ch in text)
            {
                if (char.IsUpper(ch))
                {
                    if (result.Length > 0)
                    {
                        result.Append(' ');
                    }
                    result.Append(ch);
                }
                else
                {
                    //Lowercase something
                    if (ch != '_')
                    {
                        if (prevChar == '_')
                        {
                            if (result.Length > 0)
                            {
                                result.Append(' ');
                            }
                            result.Append(char.ToUpper(ch));
                        }
                        else
                        {
                            if (result.Length == 0)
                            {
                                result.Append(char.ToUpper(ch));
                            }
                            else
                            {
                                result.Append(ch);
                            }
                        }
                    }
                }
                prevChar = ch;
            }
            var r = result.ToString();
            return r;
        }
    }

}



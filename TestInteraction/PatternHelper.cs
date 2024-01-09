using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInteraction
{
    internal static class PatternHelper
    {
        public static int GetStartIndex(Pattern ptn, string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (Pattern.Match(ptn, str.Substring(i)))
                {
                    return i;
                }
            }
            return -1;
        }

        public static string ExtractText(Pattern ptn, string str)
        {
            Pattern.MatchResults results;
            for (int i = 0; i < str.Length; i++)
            {
                results = Pattern.GetMatchTo(ptn, str.Substring(i));
                if (results.MatchFound)
                {
                    return str.Substring(i,results.EndIndex);
                }
            }

            return "NULL";
        }
    }
}

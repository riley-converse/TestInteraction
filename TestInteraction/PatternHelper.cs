using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInteraction
{
    public static class PatternHelper
    {
        public static string? ExtractText(Pattern ptn, string txt)
        {
            var results = ptn.Match(txt);
            if (results.MatchFound)
                return (txt.Substring(results.StartIndex, (results.EndIndex-results.StartIndex)+1));
            
            return null;
        }

        public static int GetStartIndex(Pattern ptn, string txt)
        {
            var results = ptn.Match(txt);
            if (results.MatchFound)
                return (results.StartIndex);
            return -1;
        }

    }
}

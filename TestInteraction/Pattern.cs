using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInteraction
{
    public class Pattern
    {
        private readonly ICharSet[] _charSetDefinition;

        public Pattern(params ICharSet[] args) 
        { 
            _charSetDefinition = args;
        }
        
        // Breaks a pattern down into charsets and stores them in our definitions. 
        public Pattern(params Pattern[] args)
        {
            List<ICharSet> temp = new List<ICharSet>();
            for (int i = 0; i < args.Length; i++)
            {
                for (int j = 0; j < args[i]._charSetDefinition.Length; j++)
                {
                    temp.Add(args[i]._charSetDefinition[j]);
                }
            }
            _charSetDefinition = temp.ToArray();
        }

        // Loop through each internal definition and make sure we get an exact in sequential order. 
        public MatchResults Match(string str)
        {
            var startIndex = 0;
            var endIndex = 0;
            var stringIndex = 0;
            for (var defIndex = 0; defIndex < _charSetDefinition.Length; defIndex++)
            {
                if (stringIndex >= str.Length) return new MatchResults(false, -1, -1);
                if (_charSetDefinition[defIndex].Match(str[stringIndex]))
                {
                    if (defIndex == 0) {startIndex = stringIndex;}
                }
                else
                {
                    if (defIndex != 0) {stringIndex = startIndex;}
                    defIndex = -1;
                }
                stringIndex++;
            }

            endIndex = stringIndex-1;
            return (new MatchResults(true, startIndex, endIndex));
        }
        
        // return the index of the first instance of a match being found. 
        public int FindFirstInstance(string str, int definitionIndex=0)
        {
            var stringIndex = 0;
            foreach (char ch in str)
            {
                if (_charSetDefinition[definitionIndex].Match(ch))
                    return stringIndex;
                stringIndex++;
            }
            return -1;
        }
        
        public static Pattern operator +(Pattern left, Pattern right)
        {
            return new Pattern(left, right);
        }

        public record MatchResults(bool MatchFound, int StartIndex, int EndIndex);
    }
}

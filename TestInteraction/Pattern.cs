using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInteraction
{
    internal class Pattern
    {
        private readonly Sequence[] _behavior;
        private readonly int _index;
        public Pattern(params Sequence[] args) 
        { 
            _behavior = args;
            _index = 0;
        }

        public Pattern(params Pattern[] args)
        {
            List<Sequence> temp = new List<Sequence>();
            for (int i = 0; i < args.Length; i++)
            {
                for (int j = 0; j < args[i]._behavior.Length; j++)
                {
                    temp.Add(args[i]._behavior[j]);
                }
            }
            _behavior = temp.ToArray();
        }

        // Starts at beginning of string, runs pattern until each sequence is satisfied,
        // returns false if any sequence fails, returns true if it reaches the end
        public MatchResults Match(string str)
        {
            int index = 0;
            foreach (char ch in str)
            {
                if (_behavior[index].Match(ch))
                {
                    index++;
                    if (index >= _behavior.Length)
                    {
                        return new MatchResults(true, index);
                    }
                }
                else { return new MatchResults(false, -1); }
            }
            return new MatchResults(false, -1);
        }

        public static bool Match(Pattern seq, string str)
        {
            if (seq.Match(str).MatchFound) { return true; }
            return false;
        }

        /*public static Sequence operator +(Pattern d, Sequence left, Sequence right)
        {
            return new Sequence();
        }*/

        public static MatchResults GetMatchTo(Pattern seq, string str)
        {
            return seq.Match(str);
        }

        public record MatchResults(bool MatchFound, int EndIndex);
    }
}

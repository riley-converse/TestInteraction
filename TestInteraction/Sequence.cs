using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace TestInteraction
{
    internal class Sequence
    {
        private  static readonly char[] _letter = { 'a', 'b', 'c', 'd', 'e' };
        public static readonly char[] Number = { '1', '2', '3', '4', '5' };


        public static readonly Sequence Letter = new Sequence(_letter);

        private readonly char[] _contents;



        public Sequence(params char[] args)
        {
            _contents = args;
        }

        public bool Match(char c)
        {
            foreach (char ch in _contents)
            {
                if (ch == c) return true;
            }
            return false;
        }

        public static Sequence operator *(Sequence sqc, int n)
        {

        }


        /*public bool Match(Sequence seq)
        {
            foreach (char ch in _contents)
            {
                if ()
            }
        }*/
    }
}

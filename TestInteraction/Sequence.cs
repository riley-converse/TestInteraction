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

        private static List<Sequence> _boolean;
        private static int _booleanStatus = 0;

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

        public Sequence[] Repeat(int n)
        {
            Sequence[] array = new Sequence[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = new Sequence(this._contents);
            }

            return array;
        }

        public static Sequence operator ~(Sequence seq)
        {
            return new Sequence();
        }

        /*public static Sequence operator *(Sequence sqc, int n)
        {

        }*/

        private void AddToBooleanLogic(Sequence seq)
        {
            _boolean.Add(seq);
        }

        public static Sequence operator |(Sequence[] left, Sequence right)
        {

            return new Sequence();
        }


        public static Sequence operator +( Sequence seq, char c)
        {
            return new Sequence();
        }

        public static Sequence operator +(Pattern pat, Sequence seq)
        {
            return new Sequence();
        }

        public static Pattern operator +(Sequence left, Sequence right)
        {
            return new Pattern(left, right);
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

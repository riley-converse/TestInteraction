using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace TestInteraction
{
    public interface ICharSet
    {
        bool Match(char c);
        ICharSet[] Loop(int n);
    }

    public class CharSet : ICharSet
    {
        private static readonly char[] _letter = { 'a', 'b', 'c', 'd', 'e' };
        private static readonly char[] _number = { '1', '2', '3', '4', '5' };

        private static List<CharSet> _boolean;
        private static int _booleanStatus = 0;

        public static CharSet Letter => new CharSet(_letter);
        public static CharSet Number => new CharSet(_number);

    private readonly char[] _charDefinition;

        public CharSet(params char[] args)
        {
            _charDefinition = args;
        }
        
        // check if arg exists in this charset definitions.
        public bool Match(char c)
        {
            foreach (char ch in _charDefinition)
            {
                if (ch == c) return true;
            }
            return false;
        }

        // Essentially returning a pattern with n charsets.
        public ICharSet[] Loop(int n)
        {
            ICharSet[] array = new ICharSet[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = new CharSet(this._charDefinition);
            }
            return array;
        }

        public static CharSet operator ~(CharSet seq)
        {
            return null;
        }

        /*public static CharSet operator *(CharSet sqc, int n)
        {

        }*/

        private void AddToBooleanLogic(CharSet seq)
        {
            _boolean.Add(seq);
        }

        public static CharSet operator |(CharSet[] left, CharSet right)
        {

            return new CharSet();
        }


        /*
        public static CharSet operator +( CharSet seq, char c)
        {
            return new CharSet();
        }

        public static CharSet operator +(Pattern pat, CharSet seq)
        {
            return new CharSet();
        }
        */

        public static Pattern operator +(CharSet left, CharSet right)
        {
            return new Pattern(left, right);
        }
        
        public static Pattern operator +(CharSet left, Pattern right)
        {
            Pattern temp = new Pattern(left);
            return new Pattern(temp + right);
        }
        public static Pattern operator +(Pattern left, CharSet right)
        {
            Pattern temp = new Pattern(right);
            return new Pattern(left, temp);
        }

        /*public bool Match(CharSet seq)
        {
            foreach (char ch in _charDefinition)
            {
                if ()
            }
        }*/
    }
}

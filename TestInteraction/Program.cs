using LibraryInteractionTest;

namespace TestInteraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 testClass = new Class1("Hello", "World");
            while (true)
            {
                var text = testClass.OutputText();
                if (text != null) Console.WriteLine(text);
                else
                {
                    break;
                }
            }

            CharSet characterA = new CharSet('a');

            Console.WriteLine("[Char A]Character a:" + characterA.Match('a'));
            Console.WriteLine("[Char A]Character b:" + characterA.Match('b'));

            Console.WriteLine("[Letter]Character a:" + CharSet.Letter.Match('a'));
            Console.WriteLine("[Letter]Character 1:" + CharSet.Letter.Match('1'));

            Pattern word = new Pattern(CharSet.Letter, CharSet.Letter, CharSet.Letter);


            Console.WriteLine("[Letter] Index of 1abc: "+ PatternHelper.GetStartIndex(word, "156dc"));
            Pattern twoLetters = new Pattern(CharSet.Letter + CharSet.Letter);
            Console.WriteLine("[Letter] Index of 1abc: "+ PatternHelper.GetStartIndex(word, "156dc"));
            Console.WriteLine("[Letter] Index of abc: " + PatternHelper.GetStartIndex(twoLetters, "5324ad6bg7"));

            Console.WriteLine("[Letter] substring: " + PatternHelper.ExtractText(word, "12abc"));
            Console.WriteLine("[Letter] substring: " + PatternHelper.ExtractText(word, "abc"));
            Console.WriteLine("[Letter] substring: " + PatternHelper.ExtractText(twoLetters, "123bc23abc5"));

            /*Pattern testWord = new Pattern(CharSet.Letter * 3);*/
            Pattern test = new Pattern(CharSet.Letter.Loop(5));
            Console.WriteLine("[Letter] substring: " + PatternHelper.ExtractText(test, "123bc23cbabc5"));
            Pattern example = new Pattern(CharSet.Letter + CharSet.Letter);
            Console.WriteLine("[Letter] substring: " + PatternHelper.ExtractText(example, "123bc23cbabc5"));

           // Pattern testP = new Pattern(CharSet.Letter + ~CharSet.Letter + CharSet.Letter);
            CharSet cool = CharSet.Letter;


        }
    }
}

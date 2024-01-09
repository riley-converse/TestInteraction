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

            Sequence characterA = new Sequence('a');

            Console.WriteLine("[Char A]Character a:" + characterA.Match('a'));
            Console.WriteLine("[Char A]Character b:" + characterA.Match('b'));

            Console.WriteLine("[Letter]Character a:" + Sequence.Letter.Match('a'));
            Console.WriteLine("[Letter]Character 1:" + Sequence.Letter.Match('1'));

            Pattern word = new Pattern(Sequence.Letter, Sequence.Letter, Sequence.Letter);
            Console.WriteLine("[Letter]String abc" + Pattern.Match(word,"a"));
            Console.WriteLine("[Letter]String abc" + Pattern.Match(word, "a"));

            Console.WriteLine("[Letter] Index of 1abc: "+ PatternHelper.GetStartIndex(word, "156dc"));

            Console.WriteLine("[Letter] substring: " + PatternHelper.ExtractText(word, "12abc"));
            Console.WriteLine("[Letter] substring: " + PatternHelper.ExtractText(word, "abc"));
            Console.WriteLine("[Letter] substring: " + PatternHelper.ExtractText(word, "123bc23abc5"));

            /*Pattern testWord = new Pattern(Sequence.Letter * 3);*/
            Pattern test = new Pattern(Sequence.Letter.Repeat(5) | Sequence.Letter);
            Console.WriteLine("[Letter] substring: " + PatternHelper.ExtractText(test, "123bc23cbabc5"));
            Pattern example = new Pattern(Sequence.Letter + Sequence.Letter);
            Console.WriteLine("[Letter] substring: " + PatternHelper.ExtractText(example, "123bc23cbabc5"));

            Pattern testP = new Pattern(Sequence.Letter + ~Sequence.Letter + Sequence.Letter);

        }
    }
}

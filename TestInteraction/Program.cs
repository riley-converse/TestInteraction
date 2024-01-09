namespace TestInteraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            Pattern testWord = new Pattern(Sequence.Letter * 3);
        }
    }
}

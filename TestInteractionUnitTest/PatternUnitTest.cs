using Moq;
using TestInteraction;
using NUnit.Framework; 

namespace TestInteractionUnitTest;

[TestFixture]
public class PatternUnitTest
{
    //private Pattern _randomPattern;
    
    [SetUp]
    public void SetUp()
    {
        //_randomPattern = new Pattern(CharSet.Letter + CharSet.Letter + CharSet.Number);
    }

    [Test]
    [TestCase("ab34", 0,2)]
    [TestCase("87849e564ca2453", 9,11)]
    [TestCase("2d9baa56", 4,6)]
    [TestCase("bababacba2", 7,9)]
    public void Match_PassStringContainingAMatch_GetMatchResultContainingTrueAndPositiveIndex(
        string str,
        int startIndex,
        int endIndex)
    {
        CharSet letter = new CharSet('a','b','c');
        CharSet integer = new CharSet('1','2','3');
        Pattern _randomPattern = new Pattern(CharSet.Letter + CharSet.Letter + CharSet.Number);
        var results = _randomPattern.Match(str);
        
        Assert.That(results.MatchFound, Is.EqualTo(true));
        Assert.That(results.StartIndex, Is.EqualTo(startIndex));
        Assert.That(results.EndIndex, Is.EqualTo(endIndex));
    }
}
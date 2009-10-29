using NUnit.Framework;

namespace KataDictionaryReplacer.Test
{
    [TestFixture]
    public class WordWithSpaceTest
    {
        [Test]
        public void Should_Be_Equal()
        {
            Assert.That(new WordWithSpace { Word = "word", Space = ""},
                Is.EqualTo(new WordWithSpace { Word = "word", Space = "" }));
        }
        
        [Test]
        public void Different_Words_Are_Not_Equal()
        {
            Assert.That(new WordWithSpace { Word = "word1", Space = "" },
                Is.Not.EqualTo(new WordWithSpace { Word = "word", Space = "" }));
        }
        
        [Test]
        public void Different_Spaces_Are_Not_Equal()
        {
            Assert.That(new WordWithSpace { Word = "word", Space = " " },
                Is.Not.EqualTo(new WordWithSpace { Word = "word", Space = "" }));
        }
    }
}
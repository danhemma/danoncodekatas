using NUnit.Framework;

namespace KataDictionaryReplacer.Test
{
    [TestFixture]   
    public class WordReaderTest
    {
        [Test]
        public void One_Word()
        {
            var reader = new WordReader("word");
            Assert.That(reader.NextWord(), Is.EqualTo("word"));
            Assert.That(reader.EOF(), Is.True);
        }    
        
        [Test]
        public void One_Word_With_Dollars()
        {
            var reader = new WordReader("$word$");
            Assert.That(reader.NextWord(), Is.EqualTo("$word$"));
            Assert.That(reader.EOF(), Is.True);
        }    
        
        [Test]
        public void Two_Words()
        {
            var reader = new WordReader("hello world");
            Assert.That(reader.NextWord(), Is.EqualTo("hello"));
            Assert.That(reader.NextSpace(), Is.EqualTo(" "));
            Assert.That(reader.NextWord(), Is.EqualTo("world"));
            Assert.That(reader.EOF(), Is.True);
        }   
        
        [Test]
        public void Two_Words_With_Tab()
        {
            var reader = new WordReader("hello \tworld");
            Assert.That(reader.NextWord(), Is.EqualTo("hello"));
            Assert.That(reader.NextSpace(), Is.EqualTo(" \t"));
            Assert.That(reader.NextWord(), Is.EqualTo("world"));
            Assert.That(reader.EOF(), Is.True);
        }    
    }
}
using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace KataDictionaryReplacer.Test
{
    public static class Extensions
    {
        public static IList<WordWithSpace> ToList(this IEnumerable<WordWithSpace> enumerable)
        {
            return new List<WordWithSpace>(enumerable);
        }
     }

    [TestFixture]
    public class StringSplitterTest
    {
        [Test]
        public void Test_Empty()
        {
            var splitter = new StringSplitter();
            var result = splitter.Split("").ToList();
            Assert.That(result, Is.EqualTo(new List<WordWithSpace> { }));
        }

        [Test]
        public void Test_One_Word()
        {
            var splitter = new StringSplitter();
            var result = splitter.Split("hello").ToList();
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0], Is.EqualTo(new WordWithSpace("hello", "")));
        }
        
        [Test]
        public void Test_One_Word_With_Dollars()
        {
            var splitter = new StringSplitter();
            var result = splitter.Split("$temp$").ToList();
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0], Is.EqualTo(new WordWithSpace("$temp$", "")));
        }

        [Test]
        public void Preserve_Spaces_At_End()
        {
            var splitter = new StringSplitter();
            var result = splitter.Split("hello ").ToList(); ;
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0], Is.EqualTo(new WordWithSpace("hello", " ")));
        }

        [Test]
        public void Test_Two_Words()
        {
            var splitter = new StringSplitter();
            var result = splitter.Split("hello world").ToList(); ;
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(new WordWithSpace("hello", " ")));
            Assert.That(result[1], Is.EqualTo(new WordWithSpace("world", "")));
        }
    }
}
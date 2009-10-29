using System;
using System.Collections.Specialized;

using NUnit.Framework;

namespace KataDictionaryReplacer.Test
{
    [TestFixture]
    public class ReplacingWordAssemblerTest
    {
        [Test]
        public void Test_One_Word()
        {
            var dict = new StringDictionary { { "temp", "temporary" } };
            var ass = new ReplacingWordAssembler(dict);
            var word = new WordWithSpace { Word = "$temp$", Space = "" };
            ass.Append(word);
            Assert.That(ass.GetResult(), Is.EqualTo("temporary"));
        }
    }
}
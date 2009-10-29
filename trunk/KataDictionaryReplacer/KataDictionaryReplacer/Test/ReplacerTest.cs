using System.Collections.Specialized;

using NUnit.Framework;

namespace KataDictionaryReplacer.Test
{
    [TestFixture]
    public class ReplacerTest
    {
        [Test]
        public void Test_Empty()
        {
            var dict = new StringDictionary();
            var replacer = new Replacer(dict);
            Assert.That(replacer.Replace(""), Is.EqualTo(""));
        }
        
        [Test]
        public void Test_One_Word()
        {
            var dict = new StringDictionary { { "temp", "temporary" } };
            var replacer = new Replacer(dict);
            Assert.That(replacer.Replace("$temp$"), Is.EqualTo("temporary"));
        }
        
        [Test]
        public void Manage_Dollars_In_Replaced_Word()
        {
            var dict = new StringDictionary { { "tem$p", "temporary" } };
            var replacer = new Replacer(dict);
            Assert.That(replacer.Replace("$tem$p$"), Is.EqualTo("temporary"));
        }

        [Test]
        public void Manage_Dollars_In_Non_Replaced_Word()
        {
            var dict = new StringDictionary { { "temp", "temporary" } };
            var replacer = new Replacer(dict);
            Assert.That(replacer.Replace("$temp$ wor$d"), Is.EqualTo("temporary wor$d"));
        }
        
        [Test]
        public void Manage_Double_Spaces()
        {
            var dict = new StringDictionary { { "temp", "temporary" } };
            var replacer = new Replacer(dict);
            Assert.That(replacer.Replace("$temp$  word"), Is.EqualTo("temporary  word"));
        }
        
        [Test]
        public void Manage_Newlines()
        {
            var dict = new StringDictionary { { "temp", "temporary" } };
            var replacer = new Replacer(dict);
            Assert.That(replacer.Replace("$temp$\r\nword"), 
                Is.EqualTo("temporary\r\nword"));
        }
        
        [Test]
        public void Test_Two_Words()
        {
            var dict = new StringDictionary
                       {
                           { "greeting", "Watch out!" },
                           { "name", "John Doe" }
                       };
            var replacer = new Replacer(dict);
            Assert.That(replacer.Replace("$greeting$ here comes $name$"), 
                        Is.EqualTo("Watch out! here comes John Doe"));
        }
    }
}
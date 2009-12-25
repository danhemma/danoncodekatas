using System;
using NUnit.Framework;

namespace KataRomanNumbers
{
    [TestFixture]
    public class RomanStringReaderTests
    {
        [Test]
        public void VI_Should_Read_5_1()
        {
            using (var reader = new RomanStringReader("VI"))
            {
                Assert.That(reader.Read(), Is.EqualTo(5));
                Assert.That(reader.Read(), Is.EqualTo(1));
                Assert.That(reader.EndOfString, Is.True);
            }
        }
        
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Read_On_EOF_Should_Throw_InvalidOperationException()
        {
            using (var reader = new RomanStringReader(""))
            {
                reader.Read();
            }
        }
    }
}
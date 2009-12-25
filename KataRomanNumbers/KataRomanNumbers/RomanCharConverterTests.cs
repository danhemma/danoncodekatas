using NUnit.Framework;

namespace KataRomanNumbers
{
    [TestFixture]
    public class RomanCharConverterTests
    {
        [Test]
        public void I_Should_Convert_To_1()
        {
            Assert.That(new RomanCharConverter().Convert('I'), Is.EqualTo(1));
        }
    }
}
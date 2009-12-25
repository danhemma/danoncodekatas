using System.Linq;
using NUnit.Framework;

namespace KataRomanNumbers
{
    [TestFixture]
    public class RomanNumberSplitterTests
    {
        [Test]
        public void Split_I_Should_Yield_One_Value()
        {
            Assert.That(new RomanNumberSplitter("I").Split().Count(), Is.EqualTo(1));
        }
        
        [Test]
        public void Split_II_Should_Yield_Two_Values()
        {
            Assert.That(new RomanNumberSplitter("II").Split().Count(), Is.EqualTo(2));
        }

        [Test]
        public void Split_IV_Should_Yield_One_Value()
        {
            Assert.That(new RomanNumberSplitter("IV").Split().Count(), Is.EqualTo(1));
        }

        [Test]
        public void I_ToInteger_Should_Be_1()
        {
            var RomanNumberSplitter = new RomanNumberSplitter("I");
            Assert.That(RomanNumberSplitter.Value, Is.EqualTo(1));
        }

        [Test]
        public void II_ToInteger_Should_Be_2()
        {
            Assert.That(new RomanNumberSplitter("II").Value, Is.EqualTo(2));
        }

        [Test]
        public void VI_ToInteger_Should_Be_6()
        {
            Assert.That(new RomanNumberSplitter("VI").Value, Is.EqualTo(6));
        }

        [Test]
        public void X_ToInteger_Should_Be_10()
        {
            Assert.That(new RomanNumberSplitter("X").Value, Is.EqualTo(10));
        }

        [Test]
        public void VII_ToInteger_Should_Be_7()
        {
            Assert.That(new RomanNumberSplitter("VII").Value, Is.EqualTo(7));
        }

        [Test]
        public void VIIII_ToInteger_Should_Be_9()
        {
            Assert.That(new RomanNumberSplitter("VIIII").Value, Is.EqualTo(9));
        }

        [Test]
        public void IV_ToInteger_Should_Be_4()
        {
            Assert.That(new RomanNumberSplitter("IV").Value, Is.EqualTo(4));
        }

        [Test]
        public void XC_ToInteger_Should_Be_90()
        {
            Assert.That(new RomanNumberSplitter("XC").Value, Is.EqualTo(90));
        }

        [Test]
        public void DX_ToInteger_Should_Be_510()
        {
            Assert.That(new RomanNumberSplitter("DX").Value, Is.EqualTo(510));
        }

        [Test]
        public void MXCIV_ToInteger_Should_Be_1094()
        {
            Assert.That(new RomanNumberSplitter("MXCIV").Value, Is.EqualTo(1094));
        }

    }
}
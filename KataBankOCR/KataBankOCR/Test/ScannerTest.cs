using System;
using NUnit.Framework;

namespace KataBankOCR.Test
{
    [TestFixture]
    public class ScannerTest
    {
        [Test]
        public void Test_123456789()
        {
            string input =
                "    _  _     _  _  _  _  _ " + Environment.NewLine +
                "  | _| _||_||_ |_   ||_||_|" + Environment.NewLine +
                "  ||_  _|  | _||_|  ||_| _|" + Environment.NewLine;

            var scanner = new Scanner(input);
            Assert.That(scanner.Scan(), Is.EqualTo("123456789"));
        }
        
        [Test]
        public void Test_228456165()
        {
            string input =
                " _  _  _     _  _     _  _ " + Environment.NewLine +
                " _| _||_||_||_ |_   ||_ |_ " + Environment.NewLine +
                "|_ |_ |_|  | _||_|  ||_| _|" + Environment.NewLine;

            var scanner = new Scanner(input);
            Assert.That(scanner.Scan(), Is.EqualTo("228456165 ERR"));
        }
        
        [Test]
        public void Test_Invalid_Digit()
        {
            string input =
                " _  _  _     _  _     _  _ " + Environment.NewLine +
                " _| _||_||_||_  _   ||_ |_ " + Environment.NewLine +
                "|_ |_ |_|  | _||_|  ||_| _|" + Environment.NewLine;

            var scanner = new Scanner(input);
            Assert.That(scanner.Scan(), Is.EqualTo("22845?165 ILL"));
        }
        
        [Test]
        public void Test_Two_DigtiLines()
        {
            string input =
                " _  _  _     _  _     _  _ " + Environment.NewLine +
                " _| _||_||_||_ |_   ||_ |_ " + Environment.NewLine +
                "|_ |_ |_|  | _||_|  ||_| _|" + Environment.NewLine;
            input +=
                " _  _  _     _  _     _  _ " + Environment.NewLine +
                " _| _||_||_||_  _   ||_ |_ " + Environment.NewLine +
                "|_ |_ |_|  | _||_|  ||_| _|" + Environment.NewLine;

            var scanner = new Scanner(input);
            Assert.That(scanner.Scan(), Is.EqualTo(
                "228456165 ERR" + Environment.NewLine + 
                "22845?165 ILL"));
        }
    }
}
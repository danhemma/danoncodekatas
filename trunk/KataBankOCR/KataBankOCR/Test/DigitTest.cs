using System;
using NUnit.Framework;

namespace KataBankOCR.Test
{
    [TestFixture]
    public class DigitTest
    {
        [Test]
        public void Scan_0()
        {
            string input =
               " _ " +
               "| |" +
               "|_|";
            AssertScanResult(input, 0);
        }
        
        [Test]
        public void Scan_1()
        {
            string input =
                "   " +
                "  |" +
                "  |";
            AssertScanResult(input, 1);
        }
        
        [Test]
        public void Scan_2()
        {
            string input =
                " _ " +
                " _|" +
                "|_ ";
            AssertScanResult(input, 2);
        }
        
        [Test]
        public void Scan_3()
        {
            string input =
                " _ " +
                " _|" +
                " _|";
            AssertScanResult(input, 3);
        }
        
        [Test]
        public void Scan_4()
        {
            string input =
                "   " +
                "|_|" +
                "  |";
            AssertScanResult(input, 4);
        }
        
        [Test]
        public void Scan_5()
        {
            string input =
                " _ " +
                "|_ " +
                " _|";
            AssertScanResult(input, 5);
        }
        
        [Test]
        public void Scan_6()
        {
            string input =
                " _ " +
                "|_ " +
                "|_|";
            AssertScanResult(input, 6);
        }
        
        [Test]
        public void Scan_7()
        {
            string input =
                " _ " +
                "  |" +
                "  |";
            AssertScanResult(input, 7);
        }
        
        [Test]
        public void Scan_8()
        {
            string input =
                " _ " +
                "|_|" +
                "|_|";
            AssertScanResult(input, 8);
        }
        
        [Test]
        public void Scan_9()
        {
            string input =
                " _ " +
                "|_|" +
                " _|";
            AssertScanResult(input, 9);
        }

        private void AssertScanResult(string input, int expected) 
        {
            var scanner = new Digit(input);
            Assert.That(scanner.ToChar(), 
                Is.EqualTo(Char.Parse(expected.ToString())));
        }
    }
}
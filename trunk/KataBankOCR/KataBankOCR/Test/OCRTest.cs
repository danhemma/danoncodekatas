using System;

using NUnit.Framework;

namespace KataBankOCR.Test
{
    [TestFixture]
    public class OCRTest
    {
        [Test]
        public void Test_123456789_Get_At_Index_0()
        {
            var line0 = "    _  _     _  _  _  _  _ "; 
            var line1 = "  | _| _||_||_ |_   ||_||_|"; 
            var line2 = "  ||_  _|  | _||_|  ||_| _|";

            string expected =
                "   " +
                "  |" +
                "  |";

            var ocr = new OCR(line0, line1, line2);
            Assert.That(ocr.GetDigit(0).ToChar(), 
                Is.EqualTo(new Digit(expected).ToChar()));
        }
        
        [Test]
        public void Test_123456789_Get_At_Index_1()
        {
            var line0 = "    _  _     _  _  _  _  _ ";
            var line1 = "  | _| _||_||_ |_   ||_||_|";
            var line2 = "  ||_  _|  | _||_|  ||_| _|";

            string expected =
                " _ " +
                " _|" +
                "|_ ";

            var ocr = new OCR(line0, line1, line2);
            Assert.That(ocr.GetDigit(1).ToChar(),
                Is.EqualTo(new Digit(expected).ToChar()));
        }
    }
}
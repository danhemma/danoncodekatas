using System;
using System.Collections.Generic;
using System.Linq;

namespace KataBankOCR
{
    /// <summary>
    /// Class for handling ocr codes of the format;
    ///  var line0 = "    _  _     _  _  _  _  _ "; 
    ///  var line1 = "  | _| _||_||_ |_   ||_||_|";
    ///  var line2 = "  ||_  _|  | _||_|  ||_| _|";
    /// </summary>
    public class OCR
    {
        readonly string input;
        readonly IList<Digit> digits = new List<Digit>();
        bool invalid;
        bool badChecksum;

        /// <summary>
        /// Sample input;
        ///  var line0 = "    _  _     _  _  _  _  _ "; 
        ///  var line1 = "  | _| _||_||_ |_   ||_||_|";
        ///  var line2 = "  ||_  _|  | _||_|  ||_| _|";
        /// </summary>
        /// <param name="line0">The first line</param>
        /// <param name="line1">The second line</param>
        /// <param name="line2">The third line</param>
        public OCR(string line0, string line1, string line2)
        {
            input = line0 + line1 + line2;
            Parse();
            Validate();
        }

        private void Validate()
        {
            invalid = (digits.Count(d => !d.IsValid()) > 0);
            if (!invalid)
                badChecksum = (!(new CheckSumValidator()).IsValid(DigitsString()));
        }

        private string DigitsString()
        {
            var result = "";
            foreach (var d in digits)
                result += d.ToChar();
            return result;    
        }

        private void Parse()
        {
            for (int index = 0; index < 9; index++)
                digits.Add(GetDigit(index));
        }

        /// <summary>
        /// 
        /// Sample input:
        /// " _  _  _     _  _     _  _ " + 
        /// " _| _||_||_||_ |_   ||_ |_ " + 
        /// "|_ |_ |_|  | _||_|  ||_| _|";
        /// </summary>
        /// <param name="index">Index for the requested digit</param>
        /// <returns>
        /// For index 2, return the digit at pos 2 as;
        /// " _ " + 
        /// "|_|" + 
        /// "|_|"; 
        /// </returns>
        public Digit GetDigit(int index)
        {
            return new Digit(SubStringAtIndexFromLine(index, 0) +
                   SubStringAtIndexFromLine(index, 1) +
                   SubStringAtIndexFromLine(index, 2));
        }

        private string SubStringAtIndexFromLine(int index, int line)
        {
            const int DIGIT_WIDTH = 3;
            const int LINE_WIDTH = 27;
            return input.Substring(
                index * DIGIT_WIDTH + LINE_WIDTH * line, DIGIT_WIDTH);
        }

        /// <summary>
        /// If invalid digits where found in the code, " ILL" is appended to the
        /// code. If the code did not match the checksum algorightm " ERR is appended".
        /// </summary>
        /// <returns>The ocr code as a string, e.g "123456789"</returns>
        public override string ToString()
        {
            var result = DigitsString();
            if (invalid)
                result += " ILL";
            else if (badChecksum)
                result += " ERR";
            return result;
        }
    }
}
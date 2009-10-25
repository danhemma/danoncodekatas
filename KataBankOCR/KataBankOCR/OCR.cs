using System;
using System.Collections.Generic;
using System.Linq;

namespace KataBankOCR
{
    public class OCR
    {
        private readonly string line0;
        private readonly string line1;
        private readonly string line2;
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
            this.line0 = line0;
            this.line1 = line1;
            this.line2 = line2;
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
            const int DIGIT_WIDTH = 3;
            return new Digit(
                line0.Substring(index * DIGIT_WIDTH, DIGIT_WIDTH) +
                line1.Substring(index * DIGIT_WIDTH, DIGIT_WIDTH) +
                line2.Substring(index * DIGIT_WIDTH, DIGIT_WIDTH));
        }

        /// <summary>
        /// If invalid digits where found in the code, " ILL" is appended to the
        /// code. If the code did not match the checksum algorithm " ERR" is appended".
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
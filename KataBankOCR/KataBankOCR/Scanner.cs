using System;
using System.IO;

namespace KataBankOCR
{
    /// <summary>
    /// Class for scanning input with one or more ocr codes of the format;
    ///     "    _  _     _  _  _  _  _ " + Environment.Newline +  
    ///     "  | _| _||_||_ |_   ||_||_|" + Environment.Newline + ;
    ///     "  ||_  _|  | _||_|  ||_| _|" + Environment.Newline;
    /// 
    /// Every code is three lines long and contains 9 digits. Every
    /// digit is three characters wide.
    /// 
    /// The input ends with Environment.Newline.
    /// </summary>
    public class Scanner     
    {
        private readonly string input;
        
        public Scanner(string input)
        {
            this.input = input;
        }

        /// <summary>
        /// Scan the input and generate the result.
        /// </summary>
        /// <returns>
        /// The result of the scan in format;
        /// 457508000
        /// 664371495 ERR
        /// 86110??36 ILL
        /// 
        /// Where "ERR" indicates that the ocr code did not pass the checksum
        /// algorithm and "ILL" that one or more digits where invalid.
        /// </returns>
        public string Scan()
        {
            using (var reader = new StringReader(input))
            {
                var result = new ScannerResultBuilder(reader);
                while (!reader.EOF())
                    result.ReadOCR();
                return result.GetResult();
            }
        }
    }
}
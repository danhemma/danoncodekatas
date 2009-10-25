using System;
using System.IO;
using System.Text;

namespace KataBankOCR
{
    /// <summary>
    /// Read scan input from a <see ref="TextReader"></see> and
    /// build the result one ocr at the time.
    /// </summary>
    public class ScannerResultBuilder
    {
        private readonly TextReader reader;
        private readonly StringBuilder result;
        
        public ScannerResultBuilder(TextReader reader)
        {
            this.reader = reader;
            result = new StringBuilder();
        }

        /// <summary>
        /// Read three lines from the input and append the ocr to the result.
        /// </summary>
        public void ReadOCR()
        {
            string ocrAsString = GetNextOCR().ToString();
            if (reader.EOF())
                result.Append(ocrAsString);
            else
                result.AppendLine(ocrAsString);
        }

        private OCR GetNextOCR()
        {
            // Don't remove the variables since we can't be
            // sure in which order the arguments are processed.
            var line0 = reader.ReadLine();
            var line1 = reader.ReadLine();
            var line2 = reader.ReadLine();
            return new OCR(line0, line1, line2);
        }

        /// <summary>
        /// Get the result.
        /// </summary>
        /// <returns>The result from the scan</returns>
        public string GetResult()
        {
            return result.ToString();
        }
    }
}
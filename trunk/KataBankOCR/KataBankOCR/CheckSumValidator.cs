using System;

namespace KataBankOCR
{
    public class CheckSumValidator
    {
        /// <summary>
        /// account number:  3  4  5  8  8  2  8  6  5
        /// position names:  d9 d8 d7 d6 d5 d4 d3 d2 d1
        /// 
        /// checksum calculation:
        /// (d1+2*d2+3*d3 +..+9*d9) mod 11 = 0
        /// </summary>
        /// <param name="ocrAsString">
        /// An ocr as string of length 9, 
        /// e.g. "123456789"</param>
        /// <returns></returns>
        public bool IsValid(string ocrAsString)
        {
            var chars = ocrAsString.ToCharArray();
            var sum = 0;
            for (int pos = 1; pos <= 9; pos++)
            {
                int value = int.Parse(chars[9 - pos].ToString());
                sum += value * pos;
             }
            return (sum % 11) == 0;
        }
    }
}
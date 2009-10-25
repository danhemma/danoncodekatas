using System;

namespace KataBankOCR
{
    /// <summary>
    /// Class for parsing digits in the format;
    /// string digit7 =
    ///        " _ " +
    ///        "  |" +
    ///        "  |";
    /// </summary>
    public class Digit 
    {
        private readonly string input;

        public Digit(string input)
        {
            this.input = input;
        }

        /// <summary>
        /// Sample of invalid input;
        /// string digit =
        ///        " _ " +
        ///        "| |" +
        ///        "| |";
        /// </summary>
        /// <returns><c>true</c> if the input was recognized as a char.</returns>
        public bool IsValid()
        {
            return ToChar() != '?';
        }

        /// <summary>
        /// Get the value for the digit as a <see ref="char"></see>.
        /// </summary>
        /// <returns>e.g '7'</returns>
        public char ToChar()
        {
            int code = input.GetHashCode();
            switch (code)
            {
                case 485846108:
                    return '0';
                case 1865122982:
                    return '1';
                case -1445372811:
                    return '2';
                case 900428925:
                    return '3';
                case -1441827709:
                    return '4';
                case -1610386307:
                    return '5';
                case 338779185:
                    return '6';
                case 1824294056:
                    return '7';
                case 485841969:
                    return '8';
                case -1463323523:
                    return '9';

            }
            return '?';
        }
    }
}
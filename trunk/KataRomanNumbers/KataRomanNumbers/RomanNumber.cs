using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace KataRomanNumbers
{
    public class RomanNumberSplitter
    {
        private readonly string romanNumber;

        public RomanNumberSplitter(string romanNumber)
        {
            this.romanNumber = romanNumber;
        }

        public IEnumerable<int> Split()
        {
            using (var reader = new RomanStringReader(romanNumber))
            {
                while(!reader.EndOfString)
                {
                    var value1 = reader.Read();
                    var value2 = reader.Peek();
                    bool isPrefixed = value1 < value2;
                    var value = isPrefixed ? value2 - value1 : value1;
                    if (isPrefixed)
                        reader.Skip();
                    yield return value;
                }
            }
        }

        public int Value
        {
            get
            {
                return Split().Sum();
            }
        }
    }
}
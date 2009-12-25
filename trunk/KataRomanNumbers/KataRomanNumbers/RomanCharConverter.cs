using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace KataRomanNumbers
{
    public class RomanCharConverter
    {
        private Dictionary<char, int> values = new Dictionary<char, int>
                                                   {
                                                       {'I', 1},
                                                       {'V', 5},
                                                       {'X', 10},
                                                       {'L', 50},
                                                       {'C', 100},
                                                       {'D', 500},
                                                       {'M', 1000}
                                                   };

        public int Convert(char romanChar)
        {
            return values[romanChar];
        }
    }
}